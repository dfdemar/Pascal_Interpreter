using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.message
{
    class Message
    {
        private MessageType type { get; set; }
        private Object body { get; set; }

        public Message(MessageType type, Object body)
        {
            this.type = type;
            this.body = body;
        }
    }
}
