using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCompanion.Util
{
    public class SerialHandler
    {
        private SerialMessenger serialMessenger;
        private MessageBuilder messageBuilder;

        public SerialHandler()
        {
            messageBuilder = new MessageBuilder('#', '%');
            serialMessenger = new SerialMessenger("COM4", 115200, messageBuilder);

            serialMessenger.Connect();
        }

        public void SendMessage(string message)
        {
            serialMessenger.SendMessage(message);
        }

        public string[] ReadMessages()
        {
            return serialMessenger.ReadMessages();
        }

        public string processReceivedMessage(string message)
        {
            if (message == "Scissor")
            {
                return "De robot kiest voor schaar";
            }
            else if (message == "Paper")
            {
                return "De robot kiest voor papier";
            }
            else if (message == "Rock")
            {
                return "De robot kiest voor steen";
            }

            return null;
        }
    }
}
