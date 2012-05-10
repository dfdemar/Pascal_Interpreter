using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.message
{
    public interface MessageListener
    {
        void messageReceived(Message message); // Called to receive message sent by message producer.
    }
}
