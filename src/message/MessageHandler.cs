using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Interpreter.message
{
    public class MessageHandler
    {
        private Message message;
        private ArrayList listeners;

        public MessageHandler()
        {
            this.listeners = new ArrayList();
        }

        public void addListener(MessageListener listener)
        {
            listeners.Add(listener);
        }

        public void removeListener(MessageListener listener)
        {
            listeners.Remove(listener);
        }

        public void sendMessage(Message message)
        {
            this.message = message;
            notifyListeners();
        }

        private void notifyListeners()
        {
            foreach (MessageListener listener in listeners)
                listener.messageReceived(message);
        }
    }
}
