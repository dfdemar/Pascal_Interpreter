using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.ICodeImplementation
{
    public class ICodeImplementation : ICode
    {
        public ICodeNode root { get; private set; }

        public ICodeNode SetRoot(ICodeNode node)
        {
            root = node;
            return root;
        }

        public ICodeNode GetRoot()
        {
            return root;
        }
    }
}
