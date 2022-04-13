using static JMC_Music_Server.PipeServer;

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
    /// This class only exists to hold both the message data and the client who sent it
    /// so they can both be more convieniently sent to be processed.
    /// </summary>
    class ServerMessageData
    {
        public byte[] CurrentMessage { get; set; }
        public Client CurrentClient { get; set; }
    }
}
