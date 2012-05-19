using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend.pascal
{
    public class PascalTokenType : TokenType
    {
        // RESERVED WORDS
        public static readonly PascalTokenType AND = new PascalTokenType("AND");
        public static readonly PascalTokenType ARRAY = new PascalTokenType("ARRAY");
        public static readonly PascalTokenType BEGIN = new PascalTokenType("BEGIN");
        public static readonly PascalTokenType CASE = new PascalTokenType("CASE");
        public static readonly PascalTokenType CONST = new PascalTokenType("CONST");
        public static readonly PascalTokenType DIV = new PascalTokenType("DIV");
        public static readonly PascalTokenType DO = new PascalTokenType("DO");
        public static readonly PascalTokenType DOWNTO = new PascalTokenType("DOWNTO");
        public static readonly PascalTokenType ELSE = new PascalTokenType("ELSE");
        public static readonly PascalTokenType END = new PascalTokenType("END");
        public static readonly PascalTokenType FILE = new PascalTokenType("FILE");
        public static readonly PascalTokenType FOR = new PascalTokenType("FOR");
        public static readonly PascalTokenType FUNCTION = new PascalTokenType("FUNCTION");
        public static readonly PascalTokenType GOTO = new PascalTokenType("GOTO");
        public static readonly PascalTokenType IF = new PascalTokenType("IF");
        public static readonly PascalTokenType IN = new PascalTokenType("IN");
        public static readonly PascalTokenType LABEL = new PascalTokenType("LABEL");
        public static readonly PascalTokenType MOD = new PascalTokenType("MOD");
        public static readonly PascalTokenType NIL = new PascalTokenType("NIL");
        public static readonly PascalTokenType NOT = new PascalTokenType("NOT");
        public static readonly PascalTokenType OF = new PascalTokenType("OF");
        public static readonly PascalTokenType OR = new PascalTokenType("OR");
        public static readonly PascalTokenType PACKED = new PascalTokenType("PACKED");
        public static readonly PascalTokenType PROCEDURE = new PascalTokenType("PROCEDURE");
        public static readonly PascalTokenType PROGRAM = new PascalTokenType("PROGRAM");
        public static readonly PascalTokenType RECORD = new PascalTokenType("RECORD");
        public static readonly PascalTokenType REPEAT = new PascalTokenType("REPEAT");
        public static readonly PascalTokenType SET = new PascalTokenType("SET");
        public static readonly PascalTokenType THEN = new PascalTokenType("THEN");
        public static readonly PascalTokenType TO = new PascalTokenType("TO");
        public static readonly PascalTokenType TYPE = new PascalTokenType("TYPE");
        public static readonly PascalTokenType UNTIL = new PascalTokenType("UNTIL");
        public static readonly PascalTokenType VAR = new PascalTokenType("VAR");
        public static readonly PascalTokenType WHILE = new PascalTokenType("WHILE");
        public static readonly PascalTokenType WITH = new PascalTokenType("WITH");

        // SPECIAL SYMBOLS
        public static readonly PascalTokenType PLUS = new PascalTokenType("PLUS", "+");
        public static readonly PascalTokenType MINUS = new PascalTokenType("MINUS", "-");
        public static readonly PascalTokenType STAR = new PascalTokenType("STAR", "*");
        public static readonly PascalTokenType SLASH = new PascalTokenType("SLASH", "/");
        public static readonly PascalTokenType COLON_EQUALS = new PascalTokenType("COLON_EQUALS", ":=");
        public static readonly PascalTokenType DOT = new PascalTokenType("DOT", ".");
        public static readonly PascalTokenType COMMA = new PascalTokenType("COMMA", ",");
        public static readonly PascalTokenType SEMICOLON = new PascalTokenType("SEMICOLON", ";");
        public static readonly PascalTokenType COLON = new PascalTokenType("COLON", ":");
        public static readonly PascalTokenType QUOTE = new PascalTokenType("QUOTE", "'");
        public static readonly PascalTokenType EQUALS = new PascalTokenType("EQUALS", "=");
        public static readonly PascalTokenType NOT_EQUALS = new PascalTokenType("NOT_EQUALS", "<>");
        public static readonly PascalTokenType LESS_THAN = new PascalTokenType("LESS_THAN", "<");
        public static readonly PascalTokenType LESS_EQUALS = new PascalTokenType("LESS_EQUALS", "<=");
        public static readonly PascalTokenType GREATER_EQUALS = new PascalTokenType("GREATER_EQUALS", ">=");
        public static readonly PascalTokenType GREATER_THAN = new PascalTokenType("GREATER_THAN", ">");
        public static readonly PascalTokenType LEFT_PAREN = new PascalTokenType("LEFT_PAREN", "(");
        public static readonly PascalTokenType RIGHT_PAREN = new PascalTokenType("RIGHT_PAREN", ")");
        public static readonly PascalTokenType LEFT_BRACKET = new PascalTokenType("LEFT_BRACKET", "[");
        public static readonly PascalTokenType RIGHT_BRACKET = new PascalTokenType("RIGHT_BRACKET", "]");
        public static readonly PascalTokenType LEFT_BRACE = new PascalTokenType("LEFT_BRACE", "{");
        public static readonly PascalTokenType RIGHT_BRACE = new PascalTokenType("RIGHT_BRACE", "}");
        public static readonly PascalTokenType UP_ARROW = new PascalTokenType("UP_ARROW", "^");
        public static readonly PascalTokenType DOT_DOT = new PascalTokenType("DOT_DOT", "..");

        public static readonly PascalTokenType IDENTIFIER = new PascalTokenType("IDENTIFIER");
        public static readonly PascalTokenType INTEGER = new PascalTokenType("INTEGER");
        public static readonly PascalTokenType REAL = new PascalTokenType("REAL");
        public static readonly PascalTokenType STRING = new PascalTokenType("STRING");
        public static readonly PascalTokenType ERROR = new PascalTokenType("ERROR");
        public static readonly PascalTokenType END_OF_FILE = new PascalTokenType("END_OF_FILE");

        // Set of lower-cased Pascal reserved word text strings.
        public static readonly Dictionary<string, PascalTokenType> RESERVED_WORDS = new Dictionary<string, PascalTokenType>();

        // Dictionary of Pascal special symbols. Each special symbol's text
        // is the key to its Pascal token type.
        public static readonly Dictionary<string, PascalTokenType> SPECIAL_SYMBOLS = new Dictionary<string, PascalTokenType>();

        static PascalTokenType()
        {
            RESERVED_WORDS.Add(AND.name.ToLower(), AND);
            RESERVED_WORDS.Add(ARRAY.name.ToLower(), ARRAY);
            RESERVED_WORDS.Add(BEGIN.name.ToLower(), BEGIN);
            RESERVED_WORDS.Add(CASE.name.ToLower(), CASE);
            RESERVED_WORDS.Add(CONST.name.ToLower(), CONST);
            RESERVED_WORDS.Add(DIV.name.ToLower(), DIV);
            RESERVED_WORDS.Add(DO.name.ToLower(), DO);
            RESERVED_WORDS.Add(DOWNTO.name.ToLower(), DOWNTO);
            RESERVED_WORDS.Add(ELSE.name.ToLower(), ELSE);
            RESERVED_WORDS.Add(END.name.ToLower(), END);
            RESERVED_WORDS.Add(FILE.name.ToLower(), FILE);
            RESERVED_WORDS.Add(FOR.name.ToLower(), FOR);
            RESERVED_WORDS.Add(FUNCTION.name.ToLower(), FUNCTION);
            RESERVED_WORDS.Add(GOTO.name.ToLower(), GOTO);
            RESERVED_WORDS.Add(IF.name.ToLower(), IF);
            RESERVED_WORDS.Add(IN.name.ToLower(), IN);
            RESERVED_WORDS.Add(LABEL.name.ToLower(), LABEL);
            RESERVED_WORDS.Add(MOD.name.ToLower(), MOD);
            RESERVED_WORDS.Add(NIL.name.ToLower(), NIL);
            RESERVED_WORDS.Add(NOT.name.ToLower(), NOT);
            RESERVED_WORDS.Add(OF.name.ToLower(), OF);
            RESERVED_WORDS.Add(OR.name.ToLower(), OR);
            RESERVED_WORDS.Add(PACKED.name.ToLower(), PACKED);
            RESERVED_WORDS.Add(PROCEDURE.name.ToLower(), PROCEDURE);
            RESERVED_WORDS.Add(PROGRAM.name.ToLower(), PROGRAM);
            RESERVED_WORDS.Add(RECORD.name.ToLower(), RECORD);
            RESERVED_WORDS.Add(REPEAT.name.ToLower(), REPEAT);
            RESERVED_WORDS.Add(SET.name.ToLower(), SET);
            RESERVED_WORDS.Add(THEN.name.ToLower(), THEN);
            RESERVED_WORDS.Add(TO.name.ToLower(), TO);
            RESERVED_WORDS.Add(TYPE.name.ToLower(), TYPE);
            RESERVED_WORDS.Add(UNTIL.name.ToLower(), UNTIL);
            RESERVED_WORDS.Add(VAR.name.ToLower(), VAR);
            RESERVED_WORDS.Add(WHILE.name.ToLower(), WHILE);
            RESERVED_WORDS.Add(WITH.name.ToLower(), WITH);

            SPECIAL_SYMBOLS.Add(PLUS.text, PLUS);
            SPECIAL_SYMBOLS.Add(MINUS.text, MINUS);
            SPECIAL_SYMBOLS.Add(STAR.text, STAR);
            SPECIAL_SYMBOLS.Add(SLASH.text, SLASH);
            SPECIAL_SYMBOLS.Add(COLON_EQUALS.text, COLON_EQUALS);
            SPECIAL_SYMBOLS.Add(DOT.text, DOT);
            SPECIAL_SYMBOLS.Add(COMMA.text, COMMA);
            SPECIAL_SYMBOLS.Add(SEMICOLON.text, SEMICOLON);
            SPECIAL_SYMBOLS.Add(COLON.text, COLON);
            SPECIAL_SYMBOLS.Add(QUOTE.text, QUOTE);
            SPECIAL_SYMBOLS.Add(EQUALS.text, EQUALS);
            SPECIAL_SYMBOLS.Add(NOT_EQUALS.text, NOT_EQUALS);
            SPECIAL_SYMBOLS.Add(LESS_THAN.text, LESS_THAN);
            SPECIAL_SYMBOLS.Add(LESS_EQUALS.text, LESS_EQUALS);
            SPECIAL_SYMBOLS.Add(GREATER_EQUALS.text, GREATER_EQUALS);
            SPECIAL_SYMBOLS.Add(GREATER_THAN.text, GREATER_THAN);
            SPECIAL_SYMBOLS.Add(LEFT_PAREN.text, LEFT_PAREN);
            SPECIAL_SYMBOLS.Add(RIGHT_PAREN.text, RIGHT_PAREN);
            SPECIAL_SYMBOLS.Add(LEFT_BRACKET.text, LEFT_BRACKET);
            SPECIAL_SYMBOLS.Add(RIGHT_BRACKET.text, RIGHT_BRACKET);
            SPECIAL_SYMBOLS.Add(LEFT_BRACE.text, LEFT_BRACE);
            SPECIAL_SYMBOLS.Add(RIGHT_BRACE.text, RIGHT_BRACE);
            SPECIAL_SYMBOLS.Add(UP_ARROW.text, UP_ARROW);
            SPECIAL_SYMBOLS.Add(DOT_DOT.text, DOT_DOT);
        }

        public string name { get; private set; }
        public string text { get; private set; }

        PascalTokenType(string name)
        {
            this.name = name;
        }

        PascalTokenType(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
