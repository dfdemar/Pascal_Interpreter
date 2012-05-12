using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend.pascal
{
    public class PascalTokenType : TokenType
    {
        // RESERVED WORDS
        public static readonly PascalTokenType AND = new PascalTokenType();
        public static readonly PascalTokenType ARRAY = new PascalTokenType();
        public static readonly PascalTokenType BEGIN = new PascalTokenType();
        public static readonly PascalTokenType CASE = new PascalTokenType();
        public static readonly PascalTokenType CONST = new PascalTokenType();
        public static readonly PascalTokenType DIV = new PascalTokenType();
        public static readonly PascalTokenType DO = new PascalTokenType();
        public static readonly PascalTokenType DOWNTO = new PascalTokenType();
        public static readonly PascalTokenType ELSE = new PascalTokenType();
        public static readonly PascalTokenType END = new PascalTokenType();
        public static readonly PascalTokenType FILE = new PascalTokenType();
        public static readonly PascalTokenType FOR = new PascalTokenType();
        public static readonly PascalTokenType FUNCTION = new PascalTokenType();
        public static readonly PascalTokenType GOTO = new PascalTokenType();
        public static readonly PascalTokenType IF = new PascalTokenType();
        public static readonly PascalTokenType IN = new PascalTokenType();
        public static readonly PascalTokenType LABEL = new PascalTokenType();
        public static readonly PascalTokenType MOD = new PascalTokenType();
        public static readonly PascalTokenType NIL = new PascalTokenType();
        public static readonly PascalTokenType NOT = new PascalTokenType();
        public static readonly PascalTokenType OF = new PascalTokenType();
        public static readonly PascalTokenType OR = new PascalTokenType();
        public static readonly PascalTokenType PACKED = new PascalTokenType();
        public static readonly PascalTokenType PROCEDURE = new PascalTokenType();
        public static readonly PascalTokenType PROGRAM = new PascalTokenType();
        public static readonly PascalTokenType RECORD = new PascalTokenType();
        public static readonly PascalTokenType REPEAT = new PascalTokenType();
        public static readonly PascalTokenType SET = new PascalTokenType();
        public static readonly PascalTokenType THEN = new PascalTokenType();
        public static readonly PascalTokenType TO = new PascalTokenType();
        public static readonly PascalTokenType TYPE = new PascalTokenType();
        public static readonly PascalTokenType UNTIL = new PascalTokenType();
        public static readonly PascalTokenType VAR = new PascalTokenType();
        public static readonly PascalTokenType WHILE = new PascalTokenType();
        public static readonly PascalTokenType WITH = new PascalTokenType();

        // SPECIAL SYMBOLS
        public static readonly PascalTokenType PLUS = new PascalTokenType("+");
        public static readonly PascalTokenType MINUS = new PascalTokenType("-");
        public static readonly PascalTokenType STAR = new PascalTokenType("*");
        public static readonly PascalTokenType SLASH = new PascalTokenType("/");
        public static readonly PascalTokenType COLON_EQUALS = new PascalTokenType(":=");
        public static readonly PascalTokenType DOT = new PascalTokenType(".");
        public static readonly PascalTokenType COMMA = new PascalTokenType(",");
        public static readonly PascalTokenType SEMICOLON = new PascalTokenType(";");
        public static readonly PascalTokenType COLON = new PascalTokenType(":");
        public static readonly PascalTokenType QUOTE = new PascalTokenType("'");
        public static readonly PascalTokenType EQUALS = new PascalTokenType("=");
        public static readonly PascalTokenType NOT_EQUALS = new PascalTokenType("<>");
        public static readonly PascalTokenType LESS_THAN = new PascalTokenType("<");
        public static readonly PascalTokenType LESS_EQUALS = new PascalTokenType("<=");
        public static readonly PascalTokenType GREATER_EQUALS = new PascalTokenType(">=");
        public static readonly PascalTokenType GREATER_THAN = new PascalTokenType(">");
        public static readonly PascalTokenType LEFT_PAREN = new PascalTokenType("(");
        public static readonly PascalTokenType RIGHT_PAREN = new PascalTokenType(")");
        public static readonly PascalTokenType LEFT_BRACKET = new PascalTokenType("[");
        public static readonly PascalTokenType RIGHT_BRACKET = new PascalTokenType("]");
        public static readonly PascalTokenType LEFT_BRACE = new PascalTokenType("{");
        public static readonly PascalTokenType RIGHT_BRACE = new PascalTokenType("}");
        public static readonly PascalTokenType UP_ARROW = new PascalTokenType("^");
        public static readonly PascalTokenType DOT_DOT = new PascalTokenType("..");

        public static readonly PascalTokenType INDENTIFIER = new PascalTokenType();
        public static readonly PascalTokenType INTEGER = new PascalTokenType();
        public static readonly PascalTokenType REAL = new PascalTokenType();
        public static readonly PascalTokenType STRING = new PascalTokenType();
        public static readonly PascalTokenType ERROR = new PascalTokenType();
        public static readonly PascalTokenType END_OF_FILE = new PascalTokenType();

        private string text;

        PascalTokenType()
        {
            this.text = this.ToString().ToLower();
        }

        PascalTokenType(String text)
        {
            this.text = text;
        }
    }
}
