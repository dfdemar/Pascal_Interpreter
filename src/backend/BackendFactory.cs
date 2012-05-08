using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.backend.compiler;
using Interpreter.backend.interpreter;

namespace Interpreter.backend
{
    public class BackendFactory
    {
        public static Backend createBackend(String operation)
        {
            if (StringComparer.CurrentCultureIgnoreCase.Equals(operation, "compile"))
                return new CodeGenerator();
            else if (StringComparer.CurrentCultureIgnoreCase.Equals(operation, "execute"))
                return new Executor();
            else
                throw new Exception("Backend factory: Invalid operation '" + operation + "'");
        }
    }
}
