using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.frontend.pascal;

namespace Interpreter.frontend
{
    public class FrontendFactory
    {
        public static Parser createParser(string language, string type, Source source)
        {
            if (StringComparer.CurrentCultureIgnoreCase.Equals(language, "Pascal") && StringComparer.CurrentCultureIgnoreCase.Equals(type, "top-down"))
            {
                Scanner scanner = new PascalScanner(source);
                return new PascalParserTD(scanner);
            }
            else if (!StringComparer.CurrentCultureIgnoreCase.Equals(language, "Pascal"))
                throw new Exception("Parser factory: Invalid language '" + language + "'");
            else
                throw new Exception("Parser factory: Invalid type '" + type + "'");
        }
    }
}
