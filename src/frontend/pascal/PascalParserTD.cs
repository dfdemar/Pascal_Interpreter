using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.frontend;
using Interpreter.message;

namespace Interpreter.frontend.pascal
{
    class PascalParserTD :Parser
    {
        public PascalParserTD(Scanner scanner):base(scanner)
        {
        }

        public void parse()
        {
            Token token;
            long startTime = DateTime.Now.Ticks;

            while (!((token = nextToken()) is EofToken))
            {
            }

            float elapsedTime = (DateTime.Now.Ticks - startTime) / 1000f;
            sendMessage(new Message(Interpreter.message.MessageType.PARSER_SUMMARY, 
                                    new Object[] { token.getLineNumber(), getErrorCount(), elapsedTime }));
        }
    }
}
