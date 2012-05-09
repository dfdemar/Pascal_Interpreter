using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.message
{
    class Message
    {
        public MessageType type { get; private set; }
        public Object body { get; private set; }

        public Message(MessageType type, Object body)
        {
            this.type = type;
            this.body = body;
        }
    }
}
