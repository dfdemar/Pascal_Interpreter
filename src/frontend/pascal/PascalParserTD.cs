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

        // Parse a Pascal source program and generate the symbol table and the intermediate code.
        public override void parse()
        {
            long startTime = DateTime.Now.Ticks;
            iCode = ICodeFactory.CreateICode();

            try
            {
                Token token = nextToken();
                ICodeNode rootNode = null;

                // Look for the BEGIN token to parse a compound statement.
                if (token.type == PascalTokenType.BEGIN)
                {
                    StatementParser statementParser = new StatementParser(this);
                    rootNode = statementParser.parse(token);
                    token = CurrentToken();
                }
                else
                    errorHandler.flag(token, PascalErrorCode.UNEXPECTED_TOKEN, this);

                // Look for the final period.
                if (token.type != PascalTokenType.DOT)
                    errorHandler.flag(token, PascalErrorCode.MISSING_PERIOD, this);

                token = CurrentToken();

                // Set parse tree root node.
                if (rootNode != null)
                    iCode.SetRoot(rootNode);

                // Send parser summary message.
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
