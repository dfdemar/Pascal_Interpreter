using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.frontend;
using Interpreter.message;

namespace Interpreter.frontend.pascal
{
    public class PascalParserTD :Parser
    {
        protected static PascalErrorHandler errorHandler = new PascalErrorHandler();

        public PascalParserTD(Scanner scanner):base(scanner)
        {
        }

        public override void parse()
        {
            Token token;
            long startTime = DateTime.Now.Ticks;

            try
            {
                while (!((token = nextToken()) is EofToken))
                {
                    TokenType tokenType = token.type;
                    if (tokenType != PascalTokenType.ERROR)
                    {
                        // format each token
                        sendMessage(new Message(MessageType.TOKEN, new Object[]{token.lineNum,
                                                                                         token.position,
                                                                                         tokenType,
                                                                                         token.text,
                                                                                         token.value}));
                    }
                    else
                        errorHandler.flag(token, (PascalErrorCode)token.value, this);
                }

                float elapsedTime = (DateTime.Now.Ticks - startTime) / 100000f;
                sendMessage(new Message(MessageType.PARSER_SUMMARY,
                                        new IConvertible[] { token.lineNum, getErrorCount(), elapsedTime }));
            }
            catch (System.IO.IOException e)
            {
                errorHandler.abortTranslation(PascalErrorCode.IO_ERROR, this);
            }
        }

        public override int getErrorCount()
        {
            return 0;
        }
    }
}
