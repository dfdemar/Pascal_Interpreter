using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.frontend.pascal;

namespace Interpreter.frontend.pascal.tokens
{
    public class PascalStringToken : PascalToken
    {
        public PascalStringToken(Source source) : base(source)
        {
        }

        protected override void extract()
        {
            StringBuilder textBuffer = new StringBuilder();
            StringBuilder valueBuffer = new StringBuilder();

            char currentchar = nextChar();
            textBuffer.Append('\'');

            do
            {
                if (Char.IsWhiteSpace(currentchar))
                    currentchar = ' ';

                if ((currentchar != '\'') && (currentchar != Source.EOF))
                {
                    textBuffer.Append(currentchar);
                    valueBuffer.Append(currentchar);
                    currentchar = nextChar();
                }

                // Quote?  Each pair of adjacent quotes represents a single-quote.
                if (currentchar == '\'')
                {
                    while ((currentchar == '\'') && (peekChar() == '\''))
                    {
                        textBuffer.Append("''");
                        valueBuffer.Append(currentchar); // append single quote
                        currentchar = nextChar();
                        currentchar = nextChar();
                    }
                }
            } while ((currentchar != '\'') && (currentchar != Source.EOF));

            if (currentchar == '\'')
            {
                nextChar(); // consume final quote
                textBuffer.Append('\'');
                type = PascalTokenType.STRING;
                value = valueBuffer.ToString();
            }
            else
            {
                type = PascalTokenType.ERROR;
                value = PascalErrorCode.UNEXPECTED_EOF;
            }

            text = textBuffer.ToString();
        }
    }
}
