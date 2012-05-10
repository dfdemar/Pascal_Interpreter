using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend
{
    public abstract class Scanner
    {
        protected Source source;
        public Token currentToken { get; private set; }

        public Scanner(Source source)
        {
            this.source = source;
        }

        // return next token from source
        public Token nextToken()
        {
            currentToken = extractToken();
            return currentToken;
        }

        // Do the actual work of extracting and returning the next token from the source.
        // Implemented by scanner subclasses.
        protected abstract Token extractToken();

        // call the source's currentChar() method
        public char currentChar()
        {
            return source.currentChar();
        }

        // call the source's nextChar() method
        public char nextChar()
        {
            return source.nextChar();
        }
    }
}
