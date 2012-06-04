using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.ICodeImplementation
{
    public class ICodeKeyImplementation : ICodeKey
    {
        public static readonly ICodeKeyImplementation LINE = new ICodeKeyImplementation("LINE");
        public static readonly ICodeKeyImplementation ID = new ICodeKeyImplementation("ID");
        public static readonly ICodeKeyImplementation VALUE = new ICodeKeyImplementation("VALUE");

        public string name { get; private set; }

        ICodeKeyImplementation(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
