using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate;
using Interpreter.intermediate.ICodeImplementation;
using Interpreter.intermediate.SymbolTableImplementation;

namespace Interpreter.frontend.pascal.parsers
{
    public class ExpressionParser : StatementParser
    {
        private static readonly List<PascalTokenType> REL_OPS = new List<PascalTokenType>();
        private static readonly List<PascalTokenType> ADD_OPS = new List<PascalTokenType>();
        private static readonly List<PascalTokenType> MULT_OPS = new List<PascalTokenType>();
        private static readonly Dictionary<PascalTokenType, ICodeNodeType> REL_OPS_MAP = new Dictionary<PascalTokenType, ICodeNodeType>();
        private static readonly Dictionary<PascalTokenType, ICodeNodeTypeImplementation> ADD_OPS_OPS_MAP = new Dictionary<PascalTokenType, ICodeNodeTypeImplementation>();
        private static readonly Dictionary<PascalTokenType, ICodeNodeType> MULT_OPS_OPS_MAP = new Dictionary<PascalTokenType, ICodeNodeType>();

        public ExpressionParser(PascalParserTD parent) : base(parent)
        {
        }

        static ExpressionParser()
        {
            REL_OPS.Add(PascalTokenType.EQUALS);
            REL_OPS.Add(PascalTokenType.NOT_EQUALS);
            REL_OPS.Add(PascalTokenType.LESS_THAN);
            REL_OPS.Add(PascalTokenType.LESS_EQUALS);
            REL_OPS.Add(PascalTokenType.GREATER_THAN);
            REL_OPS.Add(PascalTokenType.GREATER_EQUALS);

            ADD_OPS.Add(PascalTokenType.PLUS);
            ADD_OPS.Add(PascalTokenType.MINUS);
            ADD_OPS.Add(PascalTokenType.OR);

            MULT_OPS.Add(PascalTokenType.STAR);
            MULT_OPS.Add(PascalTokenType.SLASH);
            MULT_OPS.Add(PascalTokenType.DIV);
            MULT_OPS.Add(PascalTokenType.MOD);
            MULT_OPS.Add(PascalTokenType.AND);

            REL_OPS_MAP.Add(PascalTokenType.EQUALS, ICodeNodeTypeImplementation.EQ);
            REL_OPS_MAP.Add(PascalTokenType.NOT_EQUALS, ICodeNodeTypeImplementation.NE);
            REL_OPS_MAP.Add(PascalTokenType.LESS_THAN, ICodeNodeTypeImplementation.LT);
            REL_OPS_MAP.Add(PascalTokenType.LESS_EQUALS, ICodeNodeTypeImplementation.LE);
            REL_OPS_MAP.Add(PascalTokenType.GREATER_THAN, ICodeNodeTypeImplementation.GT);
            REL_OPS_MAP.Add(PascalTokenType.GREATER_EQUALS, ICodeNodeTypeImplementation.GE);

            ADD_OPS_OPS_MAP.Add(PascalTokenType.PLUS, ICodeNodeTypeImplementation.ADD);
            ADD_OPS_OPS_MAP.Add(PascalTokenType.MINUS, ICodeNodeTypeImplementation.SUBTRACT);
            ADD_OPS_OPS_MAP.Add(PascalTokenType.OR, ICodeNodeTypeImplementation.OR);

            MULT_OPS_OPS_MAP.Add(PascalTokenType.STAR, ICodeNodeTypeImplementation.MULTIPLY);
            MULT_OPS_OPS_MAP.Add(PascalTokenType.SLASH, ICodeNodeTypeImplementation.FLOAT_DIVIDE);
            MULT_OPS_OPS_MAP.Add(PascalTokenType.DIV, ICodeNodeTypeImplementation.INTEGER_DIVIDE);
            MULT_OPS_OPS_MAP.Add(PascalTokenType.MOD, ICodeNodeTypeImplementation.MOD);
            MULT_OPS_OPS_MAP.Add(PascalTokenType.AND, ICodeNodeTypeImplementation.AND);
        }

        public override ICodeNode Parse(Token token)
        {
            return ParseExpression(token);
        }

        private ICodeNode ParseExpression(Token token)
        {
            ICodeNode rootNode = ParseSimpleExpression(token);
            token = CurrentToken();
            PascalTokenType tokenType = (PascalTokenType)token.type; // TokenType in original Java

            // Look for relational operator
            if (REL_OPS.Contains(tokenType))
            {
                // Create a new operator node and adopt the current tree as its first child.
                ICodeNodeType nodeType = REL_OPS_MAP[tokenType];
                ICodeNode opNode = ICodeFactory.CreateICodeNode(nodeType);
                opNode.AddChild(rootNode);

                token = NextToken();
                opNode.AddChild(ParseSimpleExpression(token));
                rootNode = opNode;
            }

            return rootNode;
        }

        private ICodeNode ParseSimpleExpression(Token token)
        {
            TokenType signType = null;  // type of leading sign (if any)

            // Look for a leading + or - sign.
            TokenType tokenType = token.type;
            if ((tokenType == PascalTokenType.PLUS) || (tokenType == PascalTokenType.MINUS))
            {
                signType = tokenType;
                token = NextToken();  // consume the + or -
            }

            // Parse a term and make the root of its tree the root node.
            ICodeNode rootNode = ParseTerm(token);

            // Was there a leading - sign?
            if (signType == PascalTokenType.MINUS)
            {

                // Create a NEGATE node and adopt the current tree
                // as its child. The NEGATE node becomes the new root node.
                ICodeNode negateNode = ICodeFactory.CreateICodeNode(ICodeNodeTypeImplementation.NEGATE);
                negateNode.AddChild(rootNode);
                rootNode = negateNode;
            }

            token = CurrentToken();
            tokenType = token.type;

            // Loop over additive operators.
            while (ADD_OPS.Contains(tokenType))
            {
                // Create a new operator node and adopt the current tree
                // as its first child.
                ICodeNodeType nodeType = ADD_OPS_OPS_MAP[(PascalTokenType)tokenType];
                ICodeNode opNode = ICodeFactory.CreateICodeNode(nodeType);
                opNode.AddChild(rootNode);

                token = NextToken();  // consume the operator

                // Parse another term.  The operator node adopts
                // the term's tree as its second child.
                opNode.AddChild(ParseTerm(token));

                // The operator node becomes the new root node.
                rootNode = opNode;

                token = CurrentToken();
                tokenType = token.type;
            }

            return rootNode;
        }

        private ICodeNode ParseTerm(Token token)
        {
            ICodeNode rootNode = ParseFactor(token);
            token = CurrentToken();
            TokenType tokenType = token.type;


            while (MULT_OPS.Contains(tokenType))
            {
                ICodeNodeType nodeType = MULT_OPS_OPS_MAP[(PascalTokenType)tokenType];
                ICodeNode opNode = ICodeFactory.CreateICodeNode(nodeType);
                opNode.AddChild(rootNode);

                token = NextToken(); // consume the operator
                opNode.AddChild(ParseFactor(token));
                rootNode = opNode;

                token = CurrentToken();
                tokenType = token.type;
            }

            return rootNode;
        }

        private ICodeNode ParseFactor(Token token)
        {
            TokenType tokenType = token.type;
            ICodeNode rootNode = null;

            switch (tokenType.ToString()) 
            {
                case "IDENTIFIER": 
                {
                    // Look up the identifier in the symbol table stack.
                    // Flag the identifier as undefined if it's not found.
                    String name = token.text.ToLower();
                    SymbolTableEntry id = symbolTableStack.Lookup(name);
                    if (id == null)
                    {
                        errorHandler.flag(token, PascalErrorCode.IDENTIFIER_UNDEFINED, this);
                        id = symbolTableStack.EnterLocal(name);
                    }

                    rootNode = ICodeFactory.CreateICodeNode(ICodeNodeTypeImplementation.VARIABLE);
                    rootNode.SetAttribute(ICodeKeyImplementation.ID, id);
                    id.AppendLineNumber(token.lineNumber);

                    token = NextToken();  // consume the identifier
                    break;
                }

                case "INTEGER": 
                {
                    // Create an INTEGER_CONSTANT node as the root node.
                    rootNode = ICodeFactory.CreateICodeNode(ICodeNodeTypeImplementation.INTEGER_CONSTANT);
                    rootNode.SetAttribute(ICodeKeyImplementation.VALUE, token.value);

                    token = NextToken();  // consume the number
                    break;
                }

                case "REAL": 
                {
                    // Create an REAL_CONSTANT node as the root node.
                    rootNode = ICodeFactory.CreateICodeNode(ICodeNodeTypeImplementation.REAL_CONSTANT);
                    rootNode.SetAttribute(ICodeKeyImplementation.VALUE, token.value);

                    token = NextToken();  // consume the number
                    break;
                }

                case "STRING": 
                {
                    String value = (String) token.value;

                    // Create a STRING_CONSTANT node as the root node.
                    rootNode = ICodeFactory.CreateICodeNode(ICodeNodeTypeImplementation.STRING_CONSTANT);
                    rootNode.SetAttribute(ICodeKeyImplementation.VALUE, value);

                    token = NextToken();  // consume the string
                    break;
                }

                case "NOT": 
                {
                    token = NextToken();  // consume the NOT

                    // Create a NOT node as the root node.
                    rootNode = ICodeFactory.CreateICodeNode(ICodeNodeTypeImplementation.NOT);

                    // Parse the factor.  The NOT node adopts the
                    // factor node as its child.
                    rootNode.AddChild(ParseFactor(token));

                    break;
                }

                case "LEFT_PAREN": 
                {
                    token = NextToken();      // consume the (

                    // Parse an expression and make its node the root node.
                    rootNode = ParseExpression(token);

                    // Look for the matching ) token.
                    token = CurrentToken();
                    if (token.type == PascalTokenType.RIGHT_PAREN) 
                        token = NextToken();  // consume the )
                    else
                        errorHandler.flag(token, PascalErrorCode.MISSING_RIGHT_PAREN, this);
                    break;
                }

                default: 
                {
                    errorHandler.flag(token, PascalErrorCode.UNEXPECTED_TOKEN, this);
                    break;
                }
            }

            return rootNode;
        }
    }
}
