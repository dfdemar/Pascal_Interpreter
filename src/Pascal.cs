using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Interpreter.frontend;
using Interpreter.intermediate;
using Interpreter.backend;
using Interpreter.message;

namespace Interpreter
{
    public class Pascal
    {
        private Parser parser;    // language independent parser
        private Source source;    // language independent scanner
        private ICode iCode;      // generated intermediate code
        private SymbolTable symTab;    // generated symbol table
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
                symTab = Parser.symTab;

                backend.process(iCode, symTab);
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
            catch (Exception e)
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
                            Object[] body = (Object[])message.body;  // Object is Number in Java (NEED TO LOOK INTO IConvertible Interface)
                            int statementCount = (int)body[0];
                            int syntaxErrors = (int)body[1];
                            float elapsedTime = (float)body[2];
                            Console.WriteLine(String.Format(PARSER_SUMMARY_FORMAT, statementCount, syntaxErrors, elapsedTime));
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