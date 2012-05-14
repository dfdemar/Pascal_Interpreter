using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.frontend.pascal;

namespace Interpreter.frontend.pascal.tokens
{
    public class PascalWordToken : PascalToken
    {
        public PascalWordToken(Source source) : base(source)
        {
        }

        protected void extract()
        {
            StringBuilder textBuffer = new StringBuilder();
            char currentchar = currentChar();

            while (Char.IsLetterOrDigit(currentchar))
            {
                textBuffer.Append(currentchar);
                currentchar = nextChar();
            }

            text = textBuffer.ToString();
            type = (PascalTokenType.RESERVED_WORDS.Contains(text.ToLower()) ? (TokenType)Enum.Parse(typeof(PascalTokenType), text)
                                                                            : (TokenType)PascalTokenType.IDENTIFIER);
        }
    }
}
