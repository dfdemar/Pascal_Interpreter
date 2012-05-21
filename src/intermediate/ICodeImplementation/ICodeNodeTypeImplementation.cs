using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.ICodeImplementation
{
    public class ICodeNodeTypeImplementation : ICodeNodeType
    {
        // Program Structure
        public static readonly ICodeNodeTypeImplementation PROGRAM = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation PROCEDURE = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation FUNCTION = new ICodeNodeTypeImplementation();

        // Statements
        public static readonly ICodeNodeTypeImplementation COMPOUND = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation ASSIGN = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation LOOP = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation TEST = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation CALL = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation PARAMETERS = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation IF = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation SELECT = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation SELECT_BRANCH = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation SELECT_CONSTANTS = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation NO_OP = new ICodeNodeTypeImplementation();

        // Relational Operators
        public static readonly ICodeNodeTypeImplementation EQ = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation NE = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation LT = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation LE = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation GT = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation GE = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation NOT = new ICodeNodeTypeImplementation();

        // Additive Operators
        public static readonly ICodeNodeTypeImplementation ADD = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation SUBTRACT = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation OR = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation NEGATE = new ICodeNodeTypeImplementation();

        // Multiplicative Operators
        public static readonly ICodeNodeTypeImplementation MULTIPLY = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation INTEGER_DIVIDE = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation FLOAT_DIVIDE = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation MOD = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation AND = new ICodeNodeTypeImplementation();

        // Operands
        public static readonly ICodeNodeTypeImplementation VARIABLE = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation SUBSCRIPTS = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation FIELD = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation INTEGER_CONSTANT = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation REAL_CONSTANT = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation STRING_CONSTANT = new ICodeNodeTypeImplementation();
        public static readonly ICodeNodeTypeImplementation BOOLEAN_CONSTANT = new ICodeNodeTypeImplementation();
    }
}
