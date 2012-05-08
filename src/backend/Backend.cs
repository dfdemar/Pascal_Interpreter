﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.message;
using Interpreter.intermediate;

namespace Interpreter.backend
{
    public abstract class Backend : MessageProducer
    {
        protected static MessageHandler messageHandler;

        static Backend()
        {
            messageHandler = new MessageHandler();
        }

        protected SymTab symTab { get; set; }
        protected ICode iCode { get; set; }

        // Process the intermediate code and the symbol table generated by the
        // parser.  To be implemented by a compiler or an interpreter subclass.
        public abstract void process(ICode iCode, SymTab symTab);

        public void sendMessage(Message message)
        {
            messageHandler.sendMessage(message);
        }

        public void addMessageListener(MessageListener listener)
        {
            messageHandler.addListener(listener);
        }

        public void removeMessageListener(MessageListener listener)
        {
            messageHandler.removeListener(listener);
        }
    }
}