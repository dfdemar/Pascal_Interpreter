using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.backend.interpreter
{
    public class RuntimeErrorCode
    {
        public static readonly RuntimeErrorCode UNINITIALIZED_VALUE = new RuntimeErrorCode("UNINITIALIZED_VALUE", "Uninitialized value");
        public static readonly RuntimeErrorCode VALUE_RANGE = new RuntimeErrorCode("VALUE_RANGE", "Value out of range");
        public static readonly RuntimeErrorCode INVALID_CASE_EXPRESSION_VALUE = new RuntimeErrorCode("INVALID_CASE_EXPRESSION_VALUE", "Invalid CASE expression value");
        public static readonly RuntimeErrorCode DIVISION_BY_ZERO = new RuntimeErrorCode("DIVISION_BY_ZERO", "Division by zero");
        public static readonly RuntimeErrorCode INVALID_STANDARD_FUNCTION_ARGUMENT = new RuntimeErrorCode("INVALID_STANDARD_FUNCTION_ARGUMENT", "Invalid standard function argument");
        public static readonly RuntimeErrorCode INVALID_INPUT = new RuntimeErrorCode("INVALID_INPUT", "Invalid input");
        public static readonly RuntimeErrorCode STACK_OVERFLOW = new RuntimeErrorCode("STACK_OVERFLOW", "Runtime stack overflow");
        public static readonly RuntimeErrorCode UNIMPLEMENTED_FEATURE = new RuntimeErrorCode("UNIMPLEMENTED_FEATURE", "Unimplemented runtime feature");

        public readonly string name { get; private set; }
        public readonly string message { get; private set; }

        RuntimeErrorCode(string name, string message)
        {
            this.name = name;
            this.message = message;
        }

        public string ToString()
        {
            return this.name;
        }
    }
}
