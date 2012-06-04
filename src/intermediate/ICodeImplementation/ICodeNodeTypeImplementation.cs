using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.intermediate.ICodeImplementation
{
    public class ICodeNodeTypeImplementation : ICodeNodeType
    {
        // Program Structure
        public static readonly ICodeNodeTypeImplementation PROGRAM = new ICodeNodeTypeImplementation("PROGRAM");
        public static readonly ICodeNodeTypeImplementation PROCEDURE = new ICodeNodeTypeImplementation("PROGRAM");
        public static readonly ICodeNodeTypeImplementation FUNCTION = new ICodeNodeTypeImplementation("FUNCTION");

        // Statements
        public static readonly ICodeNodeTypeImplementation COMPOUND = new ICodeNodeTypeImplementation("COMPOUND");
        public static readonly ICodeNodeTypeImplementation ASSIGN = new ICodeNodeTypeImplementation("ASSIGN");
        public static readonly ICodeNodeTypeImplementation LOOP = new ICodeNodeTypeImplementation("LOOP");
        public static readonly ICodeNodeTypeImplementation TEST = new ICodeNodeTypeImplementation("TEST");
        public static readonly ICodeNodeTypeImplementation CALL = new ICodeNodeTypeImplementation("CALL");
        public static readonly ICodeNodeTypeImplementation PARAMETERS = new ICodeNodeTypeImplementation("PARAMETERS");
        public static readonly ICodeNodeTypeImplementation IF = new ICodeNodeTypeImplementation("IF");
        public static readonly ICodeNodeTypeImplementation SELECT = new ICodeNodeTypeImplementation("SELECT");
        public static readonly ICodeNodeTypeImplementation SELECT_BRANCH = new ICodeNodeTypeImplementation("SELECT_BRANCH");
        public static readonly ICodeNodeTypeImplementation SELECT_CONSTANTS = new ICodeNodeTypeImplementation("SELECT_CONSTRAINTS");
        public static readonly ICodeNodeTypeImplementation NO_OP = new ICodeNodeTypeImplementation("NO_OP");

        // Relational Operators
        public static readonly ICodeNodeTypeImplementation EQ = new ICodeNodeTypeImplementation("EQ");
        public static readonly ICodeNodeTypeImplementation NE = new ICodeNodeTypeImplementation("NE");
        public static readonly ICodeNodeTypeImplementation LT = new ICodeNodeTypeImplementation("LT");
        public static readonly ICodeNodeTypeImplementation LE = new ICodeNodeTypeImplementation("LE");
        public static readonly ICodeNodeTypeImplementation GT = new ICodeNodeTypeImplementation("GT");
        public static readonly ICodeNodeTypeImplementation GE = new ICodeNodeTypeImplementation("GE");
        public static readonly ICodeNodeTypeImplementation NOT = new ICodeNodeTypeImplementation("NOT");

        // Additive Operators
        public static readonly ICodeNodeTypeImplementation ADD = new ICodeNodeTypeImplementation("ADD");
        public static readonly ICodeNodeTypeImplementation SUBTRACT = new ICodeNodeTypeImplementation("SUBTRACT");
        public static readonly ICodeNodeTypeImplementation OR = new ICodeNodeTypeImplementation("OR");
        public static readonly ICodeNodeTypeImplementation NEGATE = new ICodeNodeTypeImplementation("NEGATE");

        // Multiplicative Operators
        public static readonly ICodeNodeTypeImplementation MULTIPLY = new ICodeNodeTypeImplementation("MULTIPLY");
        public static readonly ICodeNodeTypeImplementation INTEGER_DIVIDE = new ICodeNodeTypeImplementation("INTEGER_DIVIDE");
        public static readonly ICodeNodeTypeImplementation FLOAT_DIVIDE = new ICodeNodeTypeImplementation("FLOAT_DIVIDE");
        public static readonly ICodeNodeTypeImplementation MOD = new ICodeNodeTypeImplementation("MOD");
        public static readonly ICodeNodeTypeImplementation AND = new ICodeNodeTypeImplementation("AND");

        // Operands
        public static readonly ICodeNodeTypeImplementation VARIABLE = new ICodeNodeTypeImplementation("VARIABLE");
        public static readonly ICodeNodeTypeImplementation SUBSCRIPTS = new ICodeNodeTypeImplementation("SUBSCRIPTS");
        public static readonly ICodeNodeTypeImplementation FIELD = new ICodeNodeTypeImplementation("FIELD");
        public static readonly ICodeNodeTypeImplementation INTEGER_CONSTANT = new ICodeNodeTypeImplementation("INTEGER_CONSTANT");
        public static readonly ICodeNodeTypeImplementation REAL_CONSTANT = new ICodeNodeTypeImplementation("REAL_CONSTANT");
        public static readonly ICodeNodeTypeImplementation STRING_CONSTANT = new ICodeNodeTypeImplementation("STRING_CONSTANT");
        public static readonly ICodeNodeTypeImplementation BOOLEAN_CONSTANT = new ICodeNodeTypeImplementation("BOOLEAN_CONSTANT");

        public string name { get; private set; }

        ICodeNodeTypeImplementation(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
