﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate;
using Interpreter.message;

namespace Interpreter.frontend
{
    public abstract class Parser : MessageProducer
    {
        public static SymTab symTab { get; protected set; }    // Generate symbol table
        protected static MessageHandler messageHandler;        // Message handler delegate

        public Scanner scanner { get; protected set; }
        public ICode iCode { get; protected set; }

        static Parser()  // static constructor
        {
            symTab = null;
            messageHandler = new MessageHandler();
        }

        protected Parser (Scanner scanner)
        {
            this.scanner = scanner;
            this.iCode = null;
        }

        public abstract void parse();
        public abstract int getErrorCount();

        public Token getCurrentToken()
        {
            return scanner.currentToken();
        }

        public Token nextToken()
        {
            return scanner.nextToken();
        }

        public void addMessageListener(MessageListener listener)
        {
            messageHandler.addListener(listener);
        }

        public void removeMessageListener(MessageListener listener)
        {
            messageHandler.removeListener(listener);
        }

        public void sendMessage(Message message)
       {
            messageHandler.sendMessage(message);
       }

    }
}