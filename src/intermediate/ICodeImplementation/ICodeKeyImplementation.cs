using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.ICodeImplementation
{
    public class ICodeKeyImplementation : ICodeKey
    {
        public static readonly ICodeKeyImplementation LINE = new ICodeKeyImplementation();
        public static readonly ICodeKeyImplementation ID = new ICodeKeyImplementation();
        public static readonly ICodeKeyImplementation VALUE = new ICodeKeyImplementation();
    }
}
