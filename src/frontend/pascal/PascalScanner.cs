using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.frontend.pascal.tokens;

namespace Interpreter.frontend.pascal
{
    public class PascalScanner : Scanner
    {
        public PascalScanner(Source source) : base(source)
        {
        }

        // Extract and return the next Pascal token from the source.
        protected override Token extractToken()
        {
            skipWhiteSpace();

            Token token;
            char currentchar = currentChar();

            // Construct the next token. The current character determines the
            // token type.
            if (currentchar == Source.EOF)
                token = new EofToken(source);
            else if (char.IsLetter(currentchar))
                token = new PascalWordToken(source);
            else if (char.IsDigit(currentchar))
                token = new PascalNumberToken(source);
            else if (currentchar == '\'')
                token = new PascalStringToken(source);
            else if (PascalTokenType.SPECIAL_SYMBOLS.ContainsKey(Char.ToString(currentchar)))
                token = new PascalSpecialSymbolToken(source);
            else
            {
                token = new PascalErrorToken(source, PascalErrorCode.INVALID_CHARACTER, Char.ToString(currentchar));
                nextChar(); // consume character
            }

            return token;
        }

        // Skips whitespace characters by consuming them. Comments are whitespace.
        private void skipWhiteSpace()
        {
            char currentchar = currentChar();

            while (Char.IsWhiteSpace(currentchar) || (currentchar == '{'))
            {
                if (currentchar == '{')
                    do
                    {
                        currentchar = nextChar();
                    } while ((currentchar != '}') && (currentchar != Source.EOF));
            }
        }
    }
}
