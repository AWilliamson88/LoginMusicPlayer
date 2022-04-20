using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Author: Andrew Williamson
/// 
/// </summary>
namespace MusicPlayer.Ipc
{
    /// <summary>
    /// This class is responsible for connecting to and communicating with the server.
    /// </summary>
    public sealed class PipeClient : IClientConnection
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(
           string pipeName,
           uint dwDesiredAccess,
           uint dwShareMode,
           IntPtr lpSecurityAttributes,
           uint dwCreationDisposition,
           uint dwFlagsAndAttributes,
           IntPtr hTemplate);

        const int BUFFER_SIZE = 4096;
        FileStream stream;
        SafeFileHandle handle;
        Thread readThread;
        public string pipeName;
        public bool shouldDisconnect;
        public bool isConnected;
        public bool isLoggedIn;

        private static readonly PipeClient _pipeClient =
            new PipeClient();

        private PipeClient()
        {
            try
            {
                Connect("\\\\.\\pipe\\myNamedPipe");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static PipeClient GetPipeClient()
        {
            return _pipeClient;
        }

        // Events and delegates.
        #region Handlers
        /// <summary>
        /// Handles the message received event
        /// </summary>
        /// <param name="messageData"></param>
        public delegate void MessageReceivedHandler(byte[] messageData);
        /// <summary>
        /// The Event that is called when a message is received from the server.
        /// </summary>
        public event EventHandler<byte[]> MessageReceived;

        /// <summary>
        /// Handles the server disconnected message.
        /// </summary>
        public delegate void ServerDisconnectedHandler();
        /// <summary>
        /// The Event that is called when the server pipe is severed.
        /// </summary>
        public event ServerDisconnectedHandler ServerDisconnected;
        #endregion

        // The connection and disconnection methods.
        #region Connection
        /// <summary>
        /// Connects client to the server with the pipename.
        /// </summary>
        /// <param name="pipename">The name of the pipe to connect to.</param>
        public void Connect(string pipename)
        {
            if (isConnected)
            {
                throw new Exception("Already connected to server.");
            }

            pipeName = pipename;
            //Console.Out.WriteLine(pipeName);

            handle = CreateFile(
                pipeName,
                0xC0000000, // GENERIC_READ | GENERIC_WRITE = 0x80000000 | 0x40000000
                0,
                IntPtr.Zero,
                3,  // OPEN_EXISTING
                0x40000000, // FILE_FLAG_OVERLAPPED
                IntPtr.Zero);

            // Couldn't create a handle.
            // The server is probably not running.
            if (handle.IsInvalid)
            {
                //TODO:  Return an enough information, so this messagebox can be moved to the form.
                MessageBox.Show(
                    "Unable to connect.\nTheServer may not be running.",
                    "Server connection Error.");
                isConnected = false;
                return;
            }

            stream = new FileStream(handle, FileAccess.ReadWrite, BUFFER_SIZE, true);
            isConnected = true;

            // Start listening for messages.
            readThread = new Thread(Read)
            {
                IsBackground = true
            };
            shouldDisconnect = false;

            readThread.Start();
        }

        /// <summary>
        /// Disconnects the client from the server.
        /// </summary>
        public void Disconnect()
        {
            shouldDisconnect = true;
            isConnected = false;
            isLoggedIn = false;

            // Clean up the resources
            if (stream != null)
            {
                stream.Close();
                stream = null;
            }

            if (handle != null)
            {
                handle.Close();
                handle = null;
            }
        }

        #endregion

        // Messages from the server.
        #region Receiving
        /// <summary>
        /// Read the message from the server.
        /// </summary>
        public void Read()
        {
            byte[] readBuffer = new byte[BUFFER_SIZE];

            while (!shouldDisconnect)
            {
                int bytesRead = 0;
                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        // Read the total stream length.
                        int totalSize = stream.Read(readBuffer, 0, 4);

                        // client had disconnected.
                        if (totalSize == 0)
                        {
                            //Console.Out.WriteLine("Client read break 1");
                            shouldDisconnect = true;
                            break;
                        }

                        totalSize = BitConverter.ToInt32(readBuffer, 0);

                        do
                        {
                            int numBytes = stream.Read(readBuffer, 0, Math.Min(totalSize - bytesRead, BUFFER_SIZE));

                            ms.Write(readBuffer, 0, numBytes);

                            bytesRead += numBytes;

                        } while (bytesRead < totalSize);
                        //Console.Out.WriteLine("Client finished reading from server");
                    }
                    catch
                    {
                        //Console.Out.WriteLine("Client read break 2");
                        shouldDisconnect = true;
                        break;
                    }

                    // Client has disconnected.
                    if (bytesRead == 0)
                    {
                        //Console.Out.WriteLine("Client read break 3");
                        shouldDisconnect = true;
                        break;
                    }

                    MessageReceived?.Invoke(this, ms.ToArray());

                }
            }

            ServerDisconnected?.Invoke();

        }

        #endregion

        // Send a message to the server.
        #region Sending
        /// <summary>
        /// Sends the message to the server.
        /// </summary>
        /// <param name="message">The message string to send to the server.</param>
        /// <returns></returns>
        public void SendMessage(string messageString)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] messageArray = encoder.GetBytes(messageString);
            //Console.Out.WriteLine("Client SendMessage(),\n" +
            //    "The message sent to the Server is: " + messageString);

            try
            {
                // Write the entire stream length.
                stream.Write(BitConverter.GetBytes(messageArray.Length), 0, 4);
                stream.Write(messageArray, 0, messageArray.Length);
                stream.Flush();
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to send the message.\n" + e, "Messaging Failure");
            }
        }

        #endregion

    }

}