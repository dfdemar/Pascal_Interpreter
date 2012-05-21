using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.ICodeImplementation
{
    public class ICodeImplementation : ICode
    {
        private ICodeNode root;

        public ICodeNode SetRoot(ICodeNode node)
        {
            root = node;
            return root;
        }
    }
}
