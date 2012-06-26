using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate;
using Interpreter.intermediate.ICodeImplementation;
using Interpreter.message;
using Interpreter.intermediate;

namespace Interpreter.backend.interpreter
{
    public class RuntimeErrorHandler
    {
        private static readonly int MAX_ERRORS = 5;
        public static int errorCount { get; private set; }

        static RuntimeErrorHandler()
        {
            errorCount = 0;
        }

        public void flag(ICodeNode node, RuntimeErrorCode errorCode, Backend backend)
        {
            string lineNumber = null;

            while ((node != null) && (node.GetAttribute(ICodeKeyImplementation.LINE) == null))
                node = node.GetParent();

            backend.sendMessage(new Message(MessageType.RUNTIME_ERROR, new Object[] { errorCode.ToString(), (int)node.GetAttribute(ICodeKeyImplementation.LINE) }));

            if (++errorCount > MAX_ERRORS)
            {
                Console.WriteLine("*** ABORTED AFTER TOO MANY RUNTIME ERRORS.");
                Environment.Exit(-1);
            }
        }
    }
}
