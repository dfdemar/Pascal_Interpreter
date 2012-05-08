using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend.pascal
{
    class PascalScanner : Scanner
    {
        public PascalScanner(Source source):base(source)
        {
        }

        // Extract and return the next Pascal token from the source.
        protected Token extractToken()
        {
            Token token;
            char currentchar = currentChar();

            // Construct the next token. The current character determines the
            // token type.
            if (currentchar == Source.EOF)
                token = new EofToken(source);
            else
                token = new Token(source);

            return token;
        }
    }
}
