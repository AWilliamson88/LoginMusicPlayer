using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

/// <summary>
/// Author: Andrew Williamson / P113357
/// Programming III
/// Assessment Tast 3
/// Question 3 - Implement your solution
/// 
/// - Must contain dynamic data structures
/// - Must contain hashing techniques
/// - Must contain sorting algorithm
/// - Must contain searching technique
/// - Must contain 3rd party library
/// - Must have a GUI
/// - Must adhere to coding standards
/// </summary>
namespace JMC_Music_Server
{
    /// <summary>
    /// This class is responsible for opening the connection and receiving clients 
    /// and their messages.
    /// </summary>
    class PipeServer
    {
        #region DllImportsAndExternalCode

        [StructLayoutAttribute(LayoutKind.Sequential)]
        struct SECURITY_DESCRIPTOR
        {
            public byte revision;
            public byte size;
            public short control;
            public IntPtr owner;
            public IntPtr group;
            public IntPtr sacl;
            public IntPtr dacl;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }

        private const uint SECURITY_DESCRIPTOR_REVISION = 1;

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool InitializeSecurityDescriptor(ref SECURITY_DESCRIPTOR sd, uint dwRevision);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool SetSecurityDescriptorDacl(ref SECURITY_DESCRIPTOR sd, bool daclPresent, IntPtr dacl, bool daclDefaulted);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateNamedPipe(
           String pipeName,
           uint dwOpenMode,
           uint dwPipeMode,
           uint nMaxInstances,
           uint nOutBufferSize,
           uint nInBufferSize,
           uint nDefaultTimeOut,
           IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int ConnectNamedPipe(
           SafeFileHandle hNamedPipe,
           IntPtr lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool DisconnectNamedPipe(SafeFileHandle hHandle);
        #endregion

        /// <summary>
        /// The size of the stream buffer.
        /// </summary>
        public const int BUFFER_SIZE = 4096;

        Thread listenThread;
        readonly List<Client> clients = new List<Client>();
        private string pipeName;
        private bool isRunning;
        private static readonly UserList ul = new UserList();

        public PipeServer()
        {
            PipeNameIs("\\\\.\\pipe\\myNamedPipe");
        }

        public class Client
        {
            public Thread ReadThread;
            public bool keepReading;
            public int id;
            public static int number = 1;
            public SafeFileHandle handle;
            public FileStream stream;
            public bool isLoggedIn;
            public ServerMessageProcessor mp;

            public Client()
            {
                id = number;
                number++;
            }
        }

        #region Accessors

        /// <summary>
        /// Returns the pipe name.
        /// </summary>
        /// <returns>string</returns>
        public string PipeNameIs()
        {
            return pipeName;
        }

        /// <summary>
        /// Set the name of the pipe.<br></br>
        /// Takes a string.
        /// </summary>
        /// <param name="newPipeName">new name for the pipe</param>
        private void PipeNameIs(string newPipeName)
        {
            pipeName = newPipeName;
        }

        /// <summary>
        /// The total number of clients connected to the server.
        /// </summary>
        public int TotalConnectedClients
        {
            get
            {
                lock (clients)
                {
                    return clients.Count;
                }
            }
        }
        #endregion

        #region handlers
        /// <summary>
        /// Handles the UpdateNumberOfClients event.
        /// </summary>
        public delegate void UpdateNumberOfClientsHandler();
        /// <summary>
        /// Event called when a client has either connected or disconnected.
        /// </summary>
        public event UpdateNumberOfClientsHandler UpdateNumberOfClients;

        /// <summary>
        /// Handles the MessageReceived evnet.
        /// </summary>
        /// <param name="serverMessageData">The message received from a client.</param>
        public delegate void MessageReceivedHandler(ServerMessageData serverMessageData);
        /// <summary>
        /// Event called when a message is received from a client.
        /// </summary>
        public event MessageReceivedHandler MessageReceived;

        /// <summary>
        /// Handles the CloseClient event.
        /// </summary>
        /// <param name="client">The client to close</param>
        public delegate void CloseClientHandler(Client client);
        /// <summary>
        /// Event called when a client needs to be closed
        /// </summary>
        public event CloseClientHandler CloseClient;
        #endregion

        #region Start-Listening
        /// <summary>
        /// Creates the a thread that listens for clients.
        /// </summary>
        public void Start()
        {
            isRunning = true;

            listenThread = new Thread(ListenForClients)
            {
                IsBackground = true
            };
            listenThread.Start();
        }

        /// <summary>
        /// When a new client connects, sets the stream and creates a new thread to listen to them.
        /// </summary>
        public void ListenForClients()
        {
            SECURITY_DESCRIPTOR sd = new SECURITY_DESCRIPTOR();

            // Set the Security Descriptor to be completely permissive. 
            InitializeSecurityDescriptor(ref sd, SECURITY_DESCRIPTOR_REVISION);
            SetSecurityDescriptorDacl(ref sd, true, IntPtr.Zero, false);

            IntPtr ptrSD = Marshal.AllocCoTaskMem(Marshal.SizeOf(sd));
            Marshal.StructureToPtr(sd, ptrSD, false);

            SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES
            {
                nLength = Marshal.SizeOf(sd),
                lpSecurityDescriptor = ptrSD,
                bInheritHandle = 1
            };

            IntPtr ptrSA = Marshal.AllocCoTaskMem(Marshal.SizeOf(sa));
            Marshal.StructureToPtr(sa, ptrSA, false);

            while (isRunning)
            {
                // Create an instance of a named pipe for one client.
                SafeFileHandle clientHandle = CreateNamedPipe(
                    PipeNameIs(),
                    // DUPLEX | FILE_FLAG_OVERLAPPED = 0x00000003 | 0x40000000;
                    0x40000003,
                    0,
                    255,
                    BUFFER_SIZE,
                    BUFFER_SIZE,
                    0,
                    ptrSA);

                // If a new named pipe can't be created restart loop.
                if (clientHandle.IsInvalid)
                {
                    continue;
                }

                int success = ConnectNamedPipe(clientHandle, IntPtr.Zero);

                // couldn't connect to client.
                if (success == 0)
                {
                    // close the handle and wait for the next client.
                    clientHandle.Close();
                    continue;
                }

                Client client = new Client
                {
                    handle = clientHandle
                };

                lock (clients)
                    clients.Add(client);

                client.stream = new FileStream(client.handle, FileAccess.ReadWrite, BUFFER_SIZE, true);

                // Create a new thread to wait for that clients mesages.
                Thread readThread = new Thread(Read)
                {
                    IsBackground = true
                };
                client.ReadThread = readThread;
                readThread.Start(client);

                UpdateNumberOfClients?.Invoke();
            }

            // Free up the pointers.
            // Never reashed here due to the infinite loop.
            Marshal.FreeCoTaskMem(ptrSD);
            Marshal.FreeCoTaskMem(ptrSA);
        }
        #endregion

        #region StopTheServer
        /// <summary>
        /// Stops the server listening for clients. 
        /// Should not be called by the listen thread.
        /// </summary>
        public void Stop()
        {
            isRunning = false;

            if (TotalConnectedClients > 0)
            {
                // Close each of the clients.
                lock (clients)
                {
                    foreach (Client c in clients)
                    {
                        c.isLoggedIn = false;
                        c.keepReading = false;
                    }
                    clients.Clear();
                }
            }

        }
        #endregion

        // I had absolutely no idea you could add a space between the words until just now.
        #region Read Messages From Client
        /// <summary>
        /// Read messages from the client sends them to be processed.
        /// </summary>
        /// <param name="clientObj">The client the thread is reading from.</param>
        private void Read(Object clientObj)
        {
            Client client = (Client)clientObj;

            client.mp = new ServerMessageProcessor(ul);

            byte[] buffer = new byte[BUFFER_SIZE];

            client.keepReading = true;
            while (client.keepReading)
            {
                int bytesRead = 0;

                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        // Read the stream length.
                        int totalSize = client.stream.Read(buffer, 0, 4);

                        // Client has disconnected.
                        if (totalSize == 0)
                        {
                            client.keepReading = false;
                            break;
                        }

                        totalSize = BitConverter.ToInt32(buffer, 0);

                        do
                        {
                            int numBytes = client.stream.Read(buffer, 0, Math.Min(totalSize - bytesRead, BUFFER_SIZE));

                            ms.Write(buffer, 0, numBytes);

                            bytesRead += numBytes;

                        } while (bytesRead < totalSize);
                    }
                    catch
                    {
                        client.keepReading = false;
                        break;
                    }

                    // Client has disconnected.
                    if (bytesRead == 0)
                    {
                        client.keepReading = false;
                        break;
                    }

                    if (isRunning)
                    {
                        byte[] array = ms.ToArray();

                        MessageReceived?.Invoke(new ServerMessageData()
                        {
                            CurrentMessage = array,
                            CurrentClient = client
                        });

                    }
                    else
                    {
                        client.keepReading = false;
                    }
                }
            }

            // The clients must be locked, otherwise "stream.Close()"
            // could be called while SendMessage(byte[]) is being called on another thread.
            // This would lead to an ID error.
            lock (clients)
            {
                // Clean up the resources
                DisconnectNamedPipe(client.handle);

                if (client.stream != null)
                {
                    client.stream.Close();
                    client.stream = null;
                }

                if (client.handle != null)
                {
                    client.handle.Close();
                    client.handle = null;
                }
                // remove the client from the list of clients.
                clients.Remove(client);
            }

            UpdateNumberOfClients?.Invoke();

        }
        #endregion

        #region Send Message to Client
        /// <summary>
        /// Send a message to a client.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="client">The client to send it to.</param>
        public void SendMessage(byte[] message, Client client)
        {
            //Console.Out.WriteLine("Message sent back to client");
            lock (clients)
            {
                byte[] messageLength = BitConverter.GetBytes(message.Length);

                client.stream.Write(messageLength, 0, 4);
                client.stream.Write(message, 0, message.Length);
                client.stream.Flush();
            }
        }
        #endregion

        /// <summary>
        /// Question 3 
        /// Contains 3rd party library
        /// Saves the list of users to a csv file using CsvHelper.
        /// </summary>
        public void SaveUserList()
        {
            ul.SaveUserList();
        }
    }
}
