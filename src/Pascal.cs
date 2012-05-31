using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Interpreter.frontend;
using Interpreter.frontend.pascal;
using Interpreter.intermediate;
using Interpreter.backend;
using Interpreter.message;
using Interpreter.util;

namespace Interpreter
{
    public class Pascal
    {
        private Parser parser;    // language independent parser
        private Source source;    // language independent scanner
        private ICode iCode;      // generated intermediate code
        private SymbolTableStack symbolTableStack;
        private Backend backend;  // backend

        public Pascal(string operation, string filePath, string flags)
        {
            try
            {
                bool intermediate = flags.IndexOf('i') > -1;
                bool xref = flags.IndexOf('x') > -1;

                source = new Source(new StreamReader(filePath));
                source.addMessageListener(new SourceMessageListener());

                parser = FrontendFactory.createParser("Pascal", "top-down", source);
                parser.addMessageListener(new ParserMessageListener());

                backend = BackendFactory.createBackend(operation);
                backend.addMessageListener(new BackendMessageListener());

                parser.parse();
                source.close();

                iCode = parser.iCode;
                symbolTableStack = Parser.symbolTableStack;

                if (xref)
                {
                    CrossReferencer crossReferencer = new CrossReferencer();
                    crossReferencer.Print(symbolTableStack);
                }

                if (intermediate) 
                {
                    ParseTreePrinter treePrinter =  new ParseTreePrinter(Console.Out);
                    treePrinter.Print(iCode);
                }
                backend.process(iCode, symbolTableStack);
            }

            catch (Exception e)
            {
                Console.WriteLine("***** Internal translator error. *****");
                Console.WriteLine(e.StackTrace);
            }
        }

        private static readonly string FLAGS = "[-ix]";
        private static readonly string USAGE = "Usage: Pascal execute|compile " + FLAGS + " <source file path>";

        public static void Main(string[] args)
        {
            try
            {
                string operation = args[0];

                if (!(StringComparer.CurrentCultureIgnoreCase.Equals(operation, "compile") || StringComparer.CurrentCultureIgnoreCase.Equals(operation, "execute")))
                    throw new Exception();

                int i = 0;
                string flags = "";

                while ((++i < args.Length) && (args[i][0] == '-'))
                    flags += args[i].Substring(1);

                // Source Path
                if (i < args.Length)
                {
                    string path = args[i];
                    new Pascal(operation, path, flags);
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine(USAGE);
            }
            Console.ReadKey();
        }

        private static readonly string SOURCE_LINE_FORMAT = "{0:000} {1}";

        // listener for source messages
        private class SourceMessageListener : MessageListener
        {
            public void messageReceived(Message message)
            {
                MessageType type = message.type;
                Object[] body = (Object[])message.body;
                switch (type)
                {
                    case MessageType.SOURCE_LINE:
                        {
                            int lineNumber = (int)body[0];
                            string lineText = (string)body[1];
                            Console.WriteLine(String.Format(SOURCE_LINE_FORMAT, lineNumber, lineText));
                            break;
                        }
                }
            }
        }

        private static readonly string PARSER_SUMMARY_FORMAT = "\n{0,2} source lines." +
                                                               "\n{1,2} syntax errors." +
                                                               "\n{2:0.00} seconds total parsing time.\n";
        private static readonly string TOKEN_FORMAT = ">>> {0,-15} line={1:000}, pos={2,2}, text=\"{3}\"";
        private static readonly String VALUE_FORMAT = ">>>                 value={0}";
        private static readonly int PREFIX_WIDTH = 5;

        // Listener for parser messages
        private class ParserMessageListener : MessageListener
        {
            public void messageReceived(Message message)
            {
                MessageType type = message.type;
                switch (type)
                {
                    case MessageType.PARSER_SUMMARY:
                        {
                            IConvertible[] body = (IConvertible[])message.body;
                            int statementCount = (int)body[0];
                            int syntaxErrors = (int)body[1];
                            float elapsedTime = (float)body[2];
                            Console.WriteLine(String.Format(PARSER_SUMMARY_FORMAT, statementCount, syntaxErrors, elapsedTime));
                            break;
                        }
                    case MessageType.TOKEN:
                        {
                            Object[] body = (Object[]) message.body;
                            int line = (int) body[0];
                            int position = (int) body[1];
                            TokenType tokenType = (TokenType) body[2];
                            string tokenText = (string)body[3];
                            Object tokenValue = body[4];
                            Console.WriteLine(TOKEN_FORMAT, tokenType, line, position, tokenText);

                            if (tokenValue != null)
                            {
                                if (tokenType == PascalTokenType.STRING)
                                {
                                    tokenValue = "\"" + tokenValue + "\"";
                                }
                                Console.WriteLine(String.Format(VALUE_FORMAT, tokenValue));
                            }

                            break;
                        }
                    case MessageType.SYNTAX_ERROR:
                        {
                            Object[] body = (Object[])message.body;
                            int lineNumber = (int)body[0];
                            int position = (int)body[1];
                            string tokenText = (string)body[2];
                            string errorMessage = (string)body[3];

                            int spaceCount = PREFIX_WIDTH + position;
                            StringBuilder flagBuffer = new StringBuilder();

                            // Spaces up to the error position
                            for (int i = 1; i < spaceCount; ++i)
                                flagBuffer.Append(' ');

                            // A pointer to the error followed by the error message
                            flagBuffer.Append("^\n*** ").Append(errorMessage);

                            // Text, if any, of the bad token.
                            if(tokenText != null)
                                flagBuffer.Append(" [at \"").Append(tokenText).Append("\"]");

                            Console.WriteLine(flagBuffer.ToString());
                            break;
                        }
                }
            }
        }

        private static readonly string INTERPRETER_SUMMARY_FORMAT = "\n{0,2} statements executed." +
                                                                    "\n{1,2} runtime errors." +
                                                                    "\n{2:0.00} seconds total execution time.\n";

        private static readonly string COMPILER_SUMMARY_FORMAT = "\n{0,2} instructions generated." +
                                                                 "\n{1:0.00} seconds total code generation time.\n";

        // Listener for back end messages
        private class BackendMessageListener : MessageListener
        {
            public void messageReceived(Message message)
            {
                MessageType type = message.type;
                switch (type)
                {
                    case MessageType.INTERPRETER_SUMMARY:
                        {
                            Object[] body = (Object[])message.body;
                            int executionCount = (int)body[0];
                            int runtimeErrors = (int)body[1];
                            float elapsedTime = (float)body[2];
                            Console.WriteLine(String.Format(INTERPRETER_SUMMARY_FORMAT, executionCount, runtimeErrors, elapsedTime));
                            break;
                        }

                    case MessageType.COMPILER_SUMMARY:
                        {
                            Object[] body = (Object[])message.body;
                            int instructionCount = (int)body[0];
                            float elapsedTime = (float)body[1];
                            Console.WriteLine(String.Format(COMPILER_SUMMARY_FORMAT, instructionCount, elapsedTime));
                            break;
                        }
                }
            }
        }
    }
}