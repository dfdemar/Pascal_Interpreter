using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend
{
    public class Token
    {
        protected TokenType type; // language specific token type
        protected string text; // token text
        protected Object value; // token value
        protected Source source; // source
        protected int lineNum { get; } // line number of the token's source line
        protected int position; // position of the first token character

        public Token(Source source)
        {
            this.source = source;
            this.lineNum = source.getLineNum();
            this.position = source.getPosition();

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
