using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.backend;
using Interpreter.intermediate;
using Interpreter.message;

namespace Interpreter.backend.interpreter
{
    public class Executor : Backend
    {
        public override void process(ICode iCode, SymbolTable symTab)
        {
            long startTime = DateTime.Now.Ticks;
            float elapsedTime = (DateTime.Now.Ticks - startTime) / 1000f;
            int executionCount = 0;
            int runtimeErrors = 0;

            sendMessage(new Message(MessageType.INTERPRETER_SUMMARY, new Object[] { executionCount, runtimeErrors, elapsedTime }));
        }
    }
}
