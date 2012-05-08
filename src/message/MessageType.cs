using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.message
{
    public enum MessageType
    {
        SOURCE_LINE, SYNTAX_ERROR,
        PARSER_SUMMARY, INTERPRETER_SUMMARY, COMPILER_SUMMARY,
        MISCELLANEOUS, TOKEN,
        ASSIGN, FETCH, BREAKPOINT, RUNTIME_ERROR,
        CALL, RETURN


     /* public static readonly MessageType SOURCE_LINE = new MessageType();
        public static readonly MessageType SYNTAX_ERROR = new MessageType();
        public static readonly MessageType PARSER_SUMMARY = new MessageType();
        public static readonly MessageType INTERPRETER_SUMMARY = new MessageType();
        public static readonly MessageType COMPILER_SUMMARY = new MessageType();
        public static readonly MessageType MISCELLANEOUS = new MessageType();
        public static readonly MessageType TOKEN = new MessageType();
        public static readonly MessageType ASSIGN = new MessageType();
        public static readonly MessageType FETCH = new MessageType();
        public static readonly MessageType BREAKPOINT = new MessageType();
        public static readonly MessageType RUNTIME_ERROR = new MessageType();
        public static readonly MessageType CALL = new MessageType();
        public static readonly MessageType RETURN = new MessageType();

        public static IEnumerable<MessageType> Values
        {
            get
            {
                yield return SOURCE_LINE;
                yield return SYNTAX_ERROR;
                yield return PARSER_SUMMARY;
                yield return INTERPRETER_SUMMARY;
                yield return COMPILER_SUMMARY;
                yield return MISCELLANEOUS;
                yield return TOKEN;
                yield return ASSIGN;
                yield return FETCH;
                yield return BREAKPOINT;
                yield return RUNTIME_ERROR;
                yield return CALL;
                yield return RETURN;
            }
        }*/
    }
}
