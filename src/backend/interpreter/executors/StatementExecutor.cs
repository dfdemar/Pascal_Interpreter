using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.intermediate;
using Interpreter.intermediate.ICodeImplementation;
using Interpreter.message;

namespace Interpreter.backend.interpreter.executors
{
    public class StatementExecutor : Executor
    {
        public StatementExecutor(Executor parent) : base(parent)
        {
        }

        public Object Execute(ICodeNode node)
        {
            ICodeNodeTypeImplementation nodeType = (ICodeNodeTypeImplementation)node.GetType();
            SendSourceLineMessage(node);

            switch (nodeType.ToString())
            {
                case "COMPOUND":
                    {
                        CompoundExecutor compoundExecutor = new CompoundExecutor(this);
                        return compoundExecutor;
                    }

                case "ASSIGN":
                    {
                        AssignmentExecutor assignmentExecutor = new AssignmentExecutor(this);
                        return assignmentExecutor;
                    }

                case "NO_OP": return null;

                default:
                    {
                        errorHandler.flag(node, RuntimeErrorCode.UNIMPLEMENTED_FEATURE, this);
                        return null;
                    }
            }
        }

        private void SendSourceLineMessage(ICodeNode node)
        {
            Object lineNumber = node.GetAttribute(ICodeKeyImplementation.LINE);

            if (lineNumber != null)
                sendMessage(new Message(MessageType.SOURCE_LINE, lineNumber));

        }
    }
}
