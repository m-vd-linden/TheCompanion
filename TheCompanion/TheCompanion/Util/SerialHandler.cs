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
            serialMessenger = new SerialMessenger("COM3", 115200, messageBuilder);

            serialMessenger.Connect();
        }

        public void SendMessage(string message)
        {
            serialMessenger.SendMessage(message);
        }
    }
}
