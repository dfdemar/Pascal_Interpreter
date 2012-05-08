using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend
{
    class EofToken : Token
    {
        public EofToken(Source source): base(source)
        {
        }

        // Do nothing. Do not consume any source characters.
        protected void extract(Source source)
        {
        }

    }
}
