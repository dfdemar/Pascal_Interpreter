using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.message;

namespace Interpreter.frontend.pascal
{
    public class PascalErrorHandler
    {
        private static readonly int MAX_ERRORS = 25;
        public static int errorCount { get; private set; } // syntax error count

        static PascalErrorHandler()
        {
            errorCount = 0;
        }

        public void flag(Token token, PascalErrorCode errorCode, Parser parser)
        {
            // Notify parser's listeners
            parser.sendMessage(new Message(MessageType.SYNTAX_ERROR, new Object[] { token.lineNumber,
                                                                                    token.position,
                                                                                    token.text,
                                                                                    errorCode.ToString()}));

            if (++errorCount > MAX_ERRORS)
                abortTranslation(PascalErrorCode.TOO_MANY_ERRORS, parser);
        }

        public void abortTranslation(PascalErrorCode errorCode, Parser parser)
        {
            String fatalText = "FATAL ERROR: " + errorCode.ToString();
            parser.sendMessage(new Message(MessageType.SYNTAX_ERROR, new Object[] {0, 0, "", fatalText}));
            Environment.Exit(errorCode.status);
        }
    }
}
