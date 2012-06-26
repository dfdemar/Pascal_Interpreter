using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate;

namespace Interpreter.backend.interpreter.executors
{
    public class CompoundExecutor : StatementExecutor
    {
        public CompoundExecutor(Executor parent) : base(parent)
        {
        }

        public Object Execute(ICodeNode node)
        {
            StatementExecutor statementExecutor = new StatementExecutor(this);
            List<ICodeNode> children = node.GetChildren();
            foreach (ICodeNode child in children)
                statementExecutor.Execute(child);

            return null;
        }

    }
}
