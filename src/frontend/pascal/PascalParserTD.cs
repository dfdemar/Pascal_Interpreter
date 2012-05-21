using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.frontend;
using Interpreter.message;
using Interpreter.intermediate;

namespace Interpreter.frontend.pascal
{
    public class PascalParserTD :Parser
    {
        protected static PascalErrorHandler errorHandler = new PascalErrorHandler();

        public PascalParserTD(PascalParserTD parent):base(parent.scanner)
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

                    if (tokenType == PascalTokenType.IDENTIFIER)
                    {
                        // Cross reference only the identifiers
                        string name = token.text.ToLower();

                        // If it's not already in the symbol table,
                        // create and enter a new entry for the identifier.
                        SymbolTableEntry entry = symbolTableStack.Lookup(name);
                        if (entry == null)
                            entry = symbolTableStack.EnterLocal(name);

                        // Append the current line number to the entry.
                        entry.AppendLineNumber(token.lineNumber);
                    }
                    else if (tokenType == PascalTokenType.ERROR)
                        errorHandler.flag(token, (PascalErrorCode)token.value, this);
                }

                float elapsedTime = (DateTime.Now.Ticks - startTime) / 10000000f;
                sendMessage(new Message(MessageType.PARSER_SUMMARY,
                                        new IConvertible[] { token.lineNumber, getErrorCount(), elapsedTime }));
            }
            catch (System.IO.IOException e)
            {
                errorHandler.abortTranslation(PascalErrorCode.IO_ERROR, this);
            }
        }

        public override int getErrorCount()
        {
            return PascalErrorHandler.errorCount;
        }
    }
}
