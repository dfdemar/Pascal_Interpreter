using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend.pascal
{
    class Description : Attribute
    {
        internal Description(string errorMessage)
        {
            this.status = 0;
            this.message = errorMessage;
        }

        internal Description(int status, string errorMessage)
        {
            this.status = status; 
            this.message = errorMessage;
        }
        public string message { get; private set; }
        public int status { get; private set; }
    }

    public enum PascalErrorCode
    {
        [Description("Already specified in FORWARD")]ALREADY_FORWARDED,
        [Description("CASE constant reused")]CASE_CONSTANT_REUSED,
        [Description("Redefined identifier")]IDENTIFIER_REDEFINED,
        [Description("Undefined identifier")]IDENTIFIER_UNDEFINED,
        [Description("Incompatible assignment")]INCOMPATIBLE_ASSIGNMENT,
        [Description("Incompatible types")]INCOMPATIBLE_TYPES,
        [Description("Invalid assignment statement")]INVALID_ASSIGNMENT,
        [Description("Invalid character")]INVALID_CHARACTER,
        [Description("Invalid constant")]INVALID_CONSTANT,
        [Description("Invalid exponent")]INVALID_EXPONENT,
        [Description("Invalid expression")]INVALID_EXPRESSION,
        [Description("Invalid field")]INVALID_FIELD,
        [Description("Invalid fraction")]INVALID_FRACTION,
        [Description("Invalid identifier usage")]INVALID_IDENTIFIER_USAGE,
        [Description("Invalid index type")]INVALID_INDEX_TYPE,
        [Description("Invalid number")]INVALID_NUMBER,
        [Description("Invalid statement")]INVALID_STATEMENT,
        [Description("Invalid subrange type")]INVALID_SUBRANGE_TYPE,
        [Description("Invalid assignment target")]INVALID_TARGET,
        [Description("Invalid type")]INVALID_TYPE,
        [Description("Invalid VAR parameter")]INVALID_VAR_PARM,
        [Description("Min limit greater than max limit")]MIN_GT_MAX,
        [Description("Missing BEGIN")]MISSING_BEGIN,
        [Description("Missing :")]MISSING_COLON,
        [Description("Missing :=")]MISSING_COLON_EQUALS,
        [Description("Missing ,")]MISSING_COMMA,
        [Description("Missing constant")]MISSING_CONSTANT,
        [Description("Missing DO")]MISSING_DO,
        [Description("Missing ..")]MISSING_DOT_DOT,
        [Description("Missing END")]MISSING_END,
        [Description("Missing =")]MISSING_EQUALS,
        [Description("Invalid FOR control variable")]MISSING_FOR_CONTROL,
        [Description("Missing identifier")]MISSING_IDENTIFIER,
        [Description("Missing [")]MISSING_LEFT_BRACKET,
        [Description("Missing OF")]MISSING_OF,
        [Description("Missing .")]MISSING_PERIOD,
        [Description("Missing PROGRAM")]MISSING_PROGRAM,
        [Description("Missing ]")]MISSING_RIGHT_BRACKET,
        [Description("Missing )")]MISSING_RIGHT_PAREN,
        [Description("Missing ;")]MISSING_SEMICOLON,
        [Description("Missing THEN")]MISSING_THEN,
        [Description("Missing TO or DOWNTO")]MISSING_TO_DOWNTO,
        [Description("Missing UNTIL")]MISSING_UNTIL,
        [Description("Missing variable")]MISSING_VARIABLE,
        [Description("Not a constant identifier")]NOT_CONSTANT_IDENTIFIER,
        [Description("Not a record variable")]NOT_RECORD_VARIABLE,
        [Description("Not a type identifier")]NOT_TYPE_IDENTIFIER,
        [Description("Integer literal out of range")]RANGE_INTEGER,
        [Description("Real literal out of range")]RANGE_REAL,
        [Description("Stack overflow")]STACK_OVERFLOW,
        [Description("Nesting level too deep")]TOO_MANY_LEVELS,
        [Description("Too many subscripts")]TOO_MANY_SUBSCRIPTS,
        [Description("Unexpected end of file")]UNEXPECTED_EOF,
        [Description("Unexpected token")]UNEXPECTED_TOKEN,
        [Description("Unimplemented feature")]UNIMPLEMENTED,
        [Description("Unrecognizable input")]UNRECOGNIZABLE,
        [Description("Wrong number of actual parameters")]WRONG_NUMBER_OF_PARMS,

        // Fatal errors
        [Description(-101, "Object I/O error")]IO_ERROR,
        [Description(-102, "Too many syntax errors")]TOO_MANY_ERRORS;
    }

    public class PascalErrorCodes
    {
        PascalErrorCodes
    }
}
