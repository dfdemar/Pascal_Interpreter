using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate;
using Interpreter.intermediate.ICodeImplementation;

namespace Interpreter.frontend.pascal.parsers
{
    public class StatementParser : PascalParserTD
    {
        public StatementParser(PascalParserTD parent) : base(parent)
        {
        }

        // Parse a statement.
        public ICodeNode Parse(Token token)
        {
            ICodeNode statementNode = null;

            switch (token.type.GetName())
            {
                case "BEGIN":
                    {
                        CompoundStatementParser compoundParser = new CompoundStatementParser(this);
                        statementNode = compoundParser.parse(token);
                        break;
                    }

                // An assignment statement begins with a variable's identifier.
                case "IDENTIFIER":
                    {
                        AssignmentStatementParser assignmentParser =
                            new AssignmentStatementParser(this);
                        statementNode = assignmentParser.parse(token);
                        break;
                    }

                default:
                    {
                        statementNode = ICodeFactory.createICodeNode(NO_OP);
                        break;
                    }
            }

            // Set the current line number as an attribute.
            SetLineNumber(statementNode, token);
            return statementNode;
        }

        // Set the current line number as a statement node attribute.
        protected internal void SetLineNumber(ICodeNode node, Token token)
        {
            if (node != null)
                node.SetAttribute(ICodeKeyImplementation.LINE, token.lineNumber);
        }

        // Parse a statement list.
        protected internal void ParseList(Token token, ICodeNode parentNode, PascalTokenType terminator, PascalErrorCode errorCode)
        {
            // Loop to parse each statement until the END token or the end of the source file.
            while (!(token is EofToken) && (token.type != terminator))
            {
                // Parse a statement.  The parent node adopts the statement node.
                ICodeNode statementNode = Parse(token);
                parentNode.AddChild(statementNode);

                token = CurrentToken();
                TokenType tokenType = token.type;

                // Look for semicolon between statements.
                if (tokenType == PascalTokenType.SEMICOLON)
                    token = NextToken();

                // If at the start of the next assignment statement, then missing a semicolon.
                else if (tokenType == PascalTokenType.IDENTIFIER)
                    errorHandler.flag(token, PascalErrorCode.MISSING_SEMICOLON, this);
            }

            if (token.type == terminator)
                token = NextToken();
            else
                errorHandler.flag(token, errorCode, this);
        }
    }
}
