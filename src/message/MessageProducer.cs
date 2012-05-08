using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.message
{
    public interface MessageProducer
    {
        public void addMessageListener(MessageListener listener);  // Add a listener to the listener list
        public void removeMessageListener(MessageListener listener); // Remove a listener from the listener list
        public void sendMessage(Message message); // Notify listeners after sending the message
    }
}
