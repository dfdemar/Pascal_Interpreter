using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend
{
    public class Token
    {
        public TokenType type { get; protected set; } // language specific token type
        public string text { get; protected set; } // token text
        public Object value { get; protected set; } // token value
        public Source source { get; protected set; } // source
        public int lineNum { get; protected set; } // line number of the token's source line
        public int position { get; protected set; } // position of the first token character

        public Token(Source source)
        {
            this.source = source;
            this.lineNum = source.lineNum;
            this.position = source.currentPos;

            extract();
        }

        /*
         * Default method to extract only one-character tokens from the source.
         * Subclasses can override this method to construct language-specific 
         * tokens.  After extracting the token, the current source line position
         * will be one beyond the last token character.
         */
        protected void extract()
        {
            text = Char.ToString(currentChar());
            value = null;
            nextChar();
        }

        // call the source's currentChar() method
        protected char currentChar()
        {
            return source.currentChar();
        }

        // call the source's nextChar() method
        protected char nextChar()
        {
            return source.nextChar();
        }

        // call the source's peekChar() method
        protected char peekChar()
        {
            return source.peekChar();
        }
    }
}
