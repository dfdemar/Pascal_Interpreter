using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreter.backend;
using Interpreter.intermediate;
using Interpreter.message;

namespace Interpreter.backend.compiler
{
    public class CodeGenerator : Backend
    {
        public override void process(ICode iCode, SymbolTable symTab)
        {
            long startTime = DateTime.Now.Ticks;
            float elapsedTime = (DateTime.Now.Ticks - startTime) / 1000f;
            int instructionCount = 0;

            sendMessage(new Message(MessageType.COMPILER_SUMMARY, new Object[] {instructionCount, elapsedTime}));
        }
    }
}
