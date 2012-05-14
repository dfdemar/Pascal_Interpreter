using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend.pascal.tokens
{
    public class PascalSpecialSymbolToken : PascalToken
    {
        public PascalSpecialSymbolToken(Source source) : base(source)
        {
        }

        protected void extract()
        {
            char currentchar = currentChar();
            text = Char.ToString(currentchar);
            type = null;

            switch (currentchar)
            {
                // Single character special symbols
                case '+':  case '-':  case '*':  case '/':  case ',':
                case ';':  case '\'': case '=':  case '(':  case ')':
                case '[':  case ']':  case '{':  case '}':  case '^':
                {
                    nextChar();
                    break;
                }

                // : or :=
                case ':':
                {
                    currentchar = nextChar();
                    if (currentchar == '=')
                        nextChar();
                    break;
                }

                // < or <= or <>
                case '<':
                    currentchar = nextChar();
                    if (currentchar == '=')
                    {
                        text += currentchar;
                        nextChar();
                    }
                    else if(currentchar == '>')
                    {
                        text += currentchar;
                        nextChar();
                    }
                    break;

                // > or >=
                case '>':
                    currentchar = nextChar();
                    if (currentchar == '=')
                    {
                        text += currentchar;
                        nextChar();
                    }
                    break;

                // . or ..
                case '.':
                    currentchar = nextChar();
                    if (currentchar == '.')
                    {
                        text += currentchar;
                        nextChar();
                    }
                    break;

                default:
                    nextChar();
                    type = PascalTokenType.ERROR;
                    value = PascalErrorCode.INVALID_CHARACTER;
                    break;
            }

            // Set up the type if it wasn't in error
            if (type == null)
                type = PascalTokenType.SPECIAL_SYMBOLS[text];
        }
    }
}
