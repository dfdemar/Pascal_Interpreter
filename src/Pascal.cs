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
        private SymTab symTab;    // generated symbol table
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
            }
        }
    }
}
