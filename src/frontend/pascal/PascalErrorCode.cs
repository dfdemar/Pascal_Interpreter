using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Interpreter.frontend.pascal
{
    public class PascalErrorCode
    {
        public static readonly PascalErrorCode ALREADY_FORWARDED = new PascalErrorCode("Already specified in FORWARD");
        public static readonly PascalErrorCode CASE_CONSTANT_REUSED = new PascalErrorCode("CASE constant reused");
        public static readonly PascalErrorCode IDENTIFIER_REDEFINED = new PascalErrorCode("Redefined identifier");
        public static readonly PascalErrorCode IDENTIFIER_UNDEFINED = new PascalErrorCode("Undefined identifier");
        public static readonly PascalErrorCode INCOMPATIBLE_ASSIGNMENT = new PascalErrorCode("Incompatible assignment");
        public static readonly PascalErrorCode INCOMPATIBLE_TYPES = new PascalErrorCode("Incompatible types");
        public static readonly PascalErrorCode INVALID_ASSIGNMENT = new PascalErrorCode("Invalid assignment statement");
        public static readonly PascalErrorCode INVALID_CHARACTER = new PascalErrorCode("Invalid character");
        public static readonly PascalErrorCode INVALID_CONSTANT = new PascalErrorCode("Invalid constant");
        public static readonly PascalErrorCode INVALID_EXPONENT = new PascalErrorCode("Invalid exponent");
        public static readonly PascalErrorCode INVALID_EXPRESSION = new PascalErrorCode("Invalid expression");
        public static readonly PascalErrorCode INVALID_FIELD = new PascalErrorCode("Invalid field");
        public static readonly PascalErrorCode INVALID_FRACTION = new PascalErrorCode("Invalid fraction");
        public static readonly PascalErrorCode INVALID_IDENTIFIER_USAGE = new PascalErrorCode("Invalid identifier usage");
        public static readonly PascalErrorCode INVALID_INDEX_TYPE = new PascalErrorCode("Invalid index type");
        public static readonly PascalErrorCode INVALID_NUMBER = new PascalErrorCode("Invalid number");
        public static readonly PascalErrorCode INVALID_STATEMENT = new PascalErrorCode("Invalid statement");
        public static readonly PascalErrorCode INVALID_SUBRANGE_TYPE = new PascalErrorCode("Invalid subrange type");
        public static readonly PascalErrorCode INVALID_TARGET = new PascalErrorCode("Invalid assignment target");
        public static readonly PascalErrorCode INVALID_TYPE = new PascalErrorCode("Invalid type");
        public static readonly PascalErrorCode INVALID_VAR_PARM = new PascalErrorCode("Invalid VAR parameter");
        public static readonly PascalErrorCode MIN_GT_MAX = new PascalErrorCode("Min limit greater than max limit");
        public static readonly PascalErrorCode MISSING_BEGIN = new PascalErrorCode("Missing BEGIN");
        public static readonly PascalErrorCode MISSING_COLON = new PascalErrorCode("Missing :");
        public static readonly PascalErrorCode MISSING_COLON_EQUALS = new PascalErrorCode("Missing :=");
        public static readonly PascalErrorCode MISSING_COMMA = new PascalErrorCode("Missing ,");
        public static readonly PascalErrorCode MISSING_CONSTANT = new PascalErrorCode("Missing constant");
        public static readonly PascalErrorCode MISSING_DO = new PascalErrorCode("Missing DO");
        public static readonly PascalErrorCode MISSING_DOT_DOT = new PascalErrorCode("Missing ..");
        public static readonly PascalErrorCode MISSING_END = new PascalErrorCode("Missing END");
        public static readonly PascalErrorCode MISSING_EQUALS = new PascalErrorCode("Missing =");
        public static readonly PascalErrorCode MISSING_FOR_CONTROL = new PascalErrorCode("Invalid FOR control variable");
        public static readonly PascalErrorCode MISSING_IDENTIFIER = new PascalErrorCode("Missing identifier");
        public static readonly PascalErrorCode MISSING_LEFT_BRACKET = new PascalErrorCode("Missing [");
        public static readonly PascalErrorCode MISSING_OF = new PascalErrorCode("Missing OF");
        public static readonly PascalErrorCode MISSING_PERIOD = new PascalErrorCode("Missing .");
        public static readonly PascalErrorCode MISSING_PROGRAM = new PascalErrorCode("Missing PROGRAM");
        public static readonly PascalErrorCode MISSING_RIGHT_BRACKET = new PascalErrorCode("Missing ]");
        public static readonly PascalErrorCode MISSING_RIGHT_PAREN = new PascalErrorCode("Missing )");
        public static readonly PascalErrorCode MISSING_SEMICOLON = new PascalErrorCode("Missing ;");
        public static readonly PascalErrorCode MISSING_THEN = new PascalErrorCode("Missing THEN");
        public static readonly PascalErrorCode MISSING_TO_DOWNTO = new PascalErrorCode("Missing TO or DOWNTO");
        public static readonly PascalErrorCode MISSING_UNTIL = new PascalErrorCode("Missing UNTIL");
        public static readonly PascalErrorCode MISSING_VARIABLE = new PascalErrorCode("Missing variable");
        public static readonly PascalErrorCode NOT_CONSTANT_IDENTIFIER = new PascalErrorCode("Not a constant identifier");
        public static readonly PascalErrorCode NOT_RECORD_VARIABLE = new PascalErrorCode("Not a record variable");
        public static readonly PascalErrorCode NOT_TYPE_IDENTIFIER = new PascalErrorCode("Not a type identifier");
        public static readonly PascalErrorCode RANGE_INTEGER = new PascalErrorCode("Integer literal out of range");
        public static readonly PascalErrorCode RANGE_REAL = new PascalErrorCode("Real literal out of range");
        public static readonly PascalErrorCode STACK_OVERFLOW = new PascalErrorCode("Stack overflow");
        public static readonly PascalErrorCode TOO_MANY_LEVELS = new PascalErrorCode("Nesting level too deep");
        public static readonly PascalErrorCode TOO_MANY_SUBSCRIPTS = new PascalErrorCode("Too many subscripts");
        public static readonly PascalErrorCode UNEXPECTED_EOF = new PascalErrorCode("Unexpected end of file");
        public static readonly PascalErrorCode UNEXPECTED_TOKEN = new PascalErrorCode("Unexpected token");
        public static readonly PascalErrorCode UNIMPLEMENTED = new PascalErrorCode("Unimplemented feature");
        public static readonly PascalErrorCode UNRECOGNIZABLE = new PascalErrorCode("Unrecognizable input");
        public static readonly PascalErrorCode WRONG_NUMBER_OF_PARMS = new PascalErrorCode ("Wrong number of actual parameters");

        // Fatal errors
        public static readonly PascalErrorCode IO_ERROR = new PascalErrorCode(-101, "Object I/O error");
        public static readonly PascalErrorCode TOO_MANY_ERRORS = new PascalErrorCode(-102, "Too many syntax errors");

        public string message { get; private set; }
        public int status { get; private set; }

        PascalErrorCode(string message)
        {
            this.status = 0;
            this.message = message;
        }

        PascalErrorCode(int status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public int getStatus()
        {
            return status;
        }

        public override string ToString()
        {
            return message;
        }
    }
}
