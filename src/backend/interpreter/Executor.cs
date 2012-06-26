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
        protected static int executionCount;
        protected static RuntimeErrorHandler errorHandler;

        static Executor()
        {
            executionCount = 0;
            errorHandler = new RuntimeErrorHandler();
        }

        public Executor()
        {
        }

        public Executor(Executor parent) : base()
        {
        }

        public override void process(ICode iCode, SymbolTableStack symbolTableStack)
        {
            this.symbolTableStack = symbolTableStack;
            this.iCode = iCode;

            long startTime = DateTime.Now.Ticks;

            ICodeNode rootNode = iCode.GetRoot();
            StatementExecutor statementExecutor = new StatementExecutor(this);
            statementExecutor.Execute(rootNode);

            float elapsedTime = (DateTime.Now.Ticks - startTime) / 1000f;
            int runtimeErrors = RuntimeErrorHandler.errorCount;

            sendMessage(new Message(MessageType.INTERPRETER_SUMMARY, new Object[] { executionCount, runtimeErrors, elapsedTime }));
        }
    }
}
