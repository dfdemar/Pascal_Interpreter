using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate
{
    public interface ICode
    {
        ICodeNode SetRoot(ICodeNode node);
        //ICodeNode GetRoot();
    }
}
