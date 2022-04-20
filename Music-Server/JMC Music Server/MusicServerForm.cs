using System;
using System.Windows.Forms;

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
    public partial class MusicServerForm : Form
    {
        readonly PipeServer pipeServer = new PipeServer();

        public MusicServerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets up the program when it first loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MusicServerForm_Load(object sender, EventArgs e)
        {
            pipeServer.UpdateNumberOfClients += PipeServer_UpdateNumberOfClients;
            pipeServer.MessageReceived += PipeServer_MessageReceived;
            StopBtn.Enabled = false;
        }

        /// <summary>
        /// Closes down the server, clients and disconnects the listeners.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MusicServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pipeServer != null)
            {
                pipeServer.Stop();
                pipeServer.SaveUserList();
                pipeServer.MessageReceived -= PipeServer_MessageReceived;
                pipeServer.UpdateNumberOfClients -= PipeServer_UpdateNumberOfClients;
            }
        }

        #region MessagesReceivedFromClients
        private void PipeServer_MessageReceived(ServerMessageData e)
        {
            Invoke(new PipeServer.MessageReceivedHandler(MessageReceived), new object[] { e });
        }

        /// <summary>
        /// Recieves the messages sent by the pipeServer from the clients, 
        /// sends them to be processed and sends the reply back to the clients.
        /// </summary>
        /// <param name="messageData"></param>
        private void MessageReceived(ServerMessageData messageData)
        {
            string str = Utility.ConvertToString(messageData.CurrentMessage);
            string[] clientMessageArray = str.Split(',');
            //Console.WriteLine("Message Code: " + clientMessageArray[0]);
            //Console.WriteLine("Message Part 1: " + clientMessageArray[1]);
            //Console.WriteLine("Message Part 2: " + clientMessageArray[2]);

            switch (clientMessageArray[0])
            {
                case "lo":
                    str = messageData.CurrentClient.mp.LoginResultProcessor(clientMessageArray);
                    // Login to an existing account.
                    break;
                case "ce":
                    str = messageData.CurrentClient.mp.AccountCreationResultProcessor(clientMessageArray);
                    // Create an account.
                    break;
                // Room for more codes.
                default:
                    // Do nothing.
                    break;
            }

            str = clientMessageArray[0] + "," + str;
            byte[] message = Utility.ConvertToBytes(str);

            pipeServer.SendMessage(message, messageData.CurrentClient);
        }
        #endregion

        #region UpdateNumberOfClients
        private void PipeServer_UpdateNumberOfClients()
        {
            Invoke(new PipeServer.UpdateNumberOfClientsHandler(UpdateNumberOfClients));
        }

        /// <summary>
        /// Updates the number of clients displayed on the server form when the
        /// UpdateNumberOfClients event is called by the pipeServer.
        /// </summary>
        private void UpdateNumberOfClients()
        {
            ClientNumberLbl.Text = pipeServer.TotalConnectedClients.ToString();
        }
        #endregion

        #region StartStopServer
        private void StartBtn_Click(object sender, EventArgs e)
        {
            pipeServer.Start();
            StartBtn.Enabled = false;
            StopBtn.Enabled = true;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            pipeServer.Stop();
            StartBtn.Enabled = true;
            StopBtn.Enabled = false;
            pipeServer.SaveUserList();
            UpdateNumberOfClients();
        }
        #endregion

    }
}
