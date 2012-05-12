using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend.pascal.tokens
{
    public class PascalErrorToken : PascalToken
    {
        public PascalErrorToken(Source source, PascalErrorCode errorCode, string tokenText) : base(source)
        {
            this.text = tokenText;
            this.type = ERROR;
            this.value = errorCode;
        }

        protected void extract()
        {
        }
    }
}
