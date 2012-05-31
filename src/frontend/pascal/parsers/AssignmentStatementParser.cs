using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate;
using Interpreter.intermediate.ICodeImplementation;
using Interpreter.frontend.pascal;

namespace Interpreter.frontend.pascal.parsers
{
    public class AssignmentStatementParser : StatementParser
    {
        public AssignmentStatementParser(PascalParserTD parent) : base(parent)
        {
        }

        public override ICodeNode Parse(Token token)
        {
            // Create the ASSIGN node.
            ICodeNode assignNode = ICodeFactory.CreateICodeNode(ICodeNodeTypeImplementation.ASSIGN);

            string targetName = token.text.ToLower();
            SymbolTableEntry targetID = symbolTableStack.Lookup(targetName);

            if (targetID == null)
                targetID = symbolTableStack.EnterLocal(targetName);

            targetID.AppendLineNumber(token.lineNumber);
            token = NextToken();

            ICodeNode variableNode = ICodeFactory.CreateICodeNode(ICodeNodeTypeImplementation.VARIABLE);
            variableNode.SetAttribute(ICodeKeyImplementation.ID, targetID);
            assignNode.AddChild(variableNode);

            if (token.type == PascalTokenType.COLON_EQUALS)
                token = NextToken();
            else
                errorHandler.flag(token, PascalErrorCode.MISSING_COLON_EQUALS, this);

            ExpressionParser expressionParser = new ExpressionParser(this);
            assignNode.AddChild(expressionParser.Parse(token));

            return assignNode;
        }
    }
}
