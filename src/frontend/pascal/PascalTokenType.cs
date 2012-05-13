using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend.pascal
{
    public enum PascalTokenType
    {
        // RESERVED WORDS
        AND, ARRAY, BEGIN, CASE, CONST, DIV, DO, DOWNTO, ELSE, END,
        FILE, FOR, FUNCTION, GOTO, IF, IN, LABEL, MOD, NIL, NOT,
        OF, OR, PACKED, PROCEDURE, PROGRAM, RECORD, REPEAT, SET,
        THEN, TO, TYPE, UNTIL, VAR, WHILE, WITH,

        // SPECIAL SYMBOLS
        PLUS, MINUS, STAR, SLASH, COLON_EQUALS, DOT, COMMA, SEMICOLON,
        COLON, QUOTE, EQUALS, NOT_EQUALS, LESS_THAN, LESS_EQUALS, GREATER_EQUALS,
        GREATER_THAN, LEFT_PAREN, RIGHT_PAREN, LEFT_BRACKET, RIGHT_BRACKET,
        LEFT_BRACE, RIGHT_BRACE, UP_ARROW, DOT_DOT,

        IDENTIFIER, INTEGER, REAL, STRING,
        ERROR, END_OF_FILE
    }

    public class PascalTokenTypeExtensions
    {
        public static HashSet<string> RESERVED_WORDS = new HashSet<string>()
            {
                PascalTokenType.AND.ToString().ToLower(),
                PascalTokenType.ARRAY.ToString().ToLower(),
                PascalTokenType.BEGIN.ToString().ToLower(),
                PascalTokenType.CASE.ToString().ToLower(),
                PascalTokenType.CONST.ToString().ToLower(),
                PascalTokenType.DIV.ToString().ToLower(),
                PascalTokenType.DO.ToString().ToLower(),
                PascalTokenType.DOWNTO.ToString().ToLower(),
                PascalTokenType.ELSE.ToString().ToLower(),
                PascalTokenType.END.ToString().ToLower(),
                PascalTokenType.FILE.ToString().ToLower(),
                PascalTokenType.FOR.ToString().ToLower(),
                PascalTokenType.FUNCTION.ToString().ToLower(),
                PascalTokenType.GOTO.ToString().ToLower(),
                PascalTokenType.IF.ToString().ToLower(),
                PascalTokenType.IN.ToString().ToLower(),
                PascalTokenType.LABEL.ToString().ToLower(),
                PascalTokenType.MOD.ToString().ToLower(),
                PascalTokenType.NIL.ToString().ToLower(),
                PascalTokenType.NOT.ToString().ToLower(),
                PascalTokenType.OF.ToString().ToLower(),
                PascalTokenType.OR.ToString().ToLower(),
                PascalTokenType.PACKED.ToString().ToLower(),
                PascalTokenType.PROCEDURE.ToString().ToLower(),
                PascalTokenType.PROGRAM.ToString().ToLower(),
                PascalTokenType.RECORD.ToString().ToLower(),
                PascalTokenType.REPEAT.ToString().ToLower(),
                PascalTokenType.SET.ToString().ToLower(),
                PascalTokenType.THEN.ToString().ToLower(),
                PascalTokenType.TO.ToString().ToLower(),
                PascalTokenType.TYPE.ToString().ToLower(),
                PascalTokenType.UNTIL.ToString().ToLower(),
                PascalTokenType.VAR.ToString().ToLower(),
                PascalTokenType.WHILE.ToString().ToLower(),
                PascalTokenType.WITH.ToString().ToLower()
            };

        private static readonly Dictionary<PascalTokenType, PascalTokenTypeText> SpecialSymbols = new Dictionary<PascalTokenType, PascalTokenTypeText>()
            {
                {PascalTokenType.PLUS, new PascalTokenTypeText("+")},
                {PascalTokenType.MINUS, new PascalTokenTypeText("-")},
                {PascalTokenType.STAR, new PascalTokenTypeText("*")},
                {PascalTokenType.SLASH, new PascalTokenTypeText("/")},
                {PascalTokenType.COLON_EQUALS, new PascalTokenTypeText(":=")},
                {PascalTokenType.DOT, new PascalTokenTypeText(".")},
                {PascalTokenType.COMMA, new PascalTokenTypeText(",")},
                {PascalTokenType.SEMICOLON, new PascalTokenTypeText(";")},
                {PascalTokenType.COLON, new PascalTokenTypeText(":")},
                {PascalTokenType.QUOTE, new PascalTokenTypeText("'")},
                {PascalTokenType.EQUALS, new PascalTokenTypeText("=")},
                {PascalTokenType.NOT_EQUALS, new PascalTokenTypeText("<>")},
                {PascalTokenType.LESS_THAN, new PascalTokenTypeText("<")},
                {PascalTokenType.LESS_EQUALS, new PascalTokenTypeText("<=")},
                {PascalTokenType.GREATER_EQUALS, new PascalTokenTypeText(">=")},
                {PascalTokenType.GREATER_THAN, new PascalTokenTypeText(">")},
                {PascalTokenType.LEFT_PAREN, new PascalTokenTypeText("(")},
                {PascalTokenType.RIGHT_PAREN, new PascalTokenTypeText(")")},
                {PascalTokenType.LEFT_BRACKET, new PascalTokenTypeText("[")},
                {PascalTokenType.RIGHT_BRACKET, new PascalTokenTypeText("]")},
                {PascalTokenType.LEFT_BRACE, new PascalTokenTypeText("{")},
                {PascalTokenType.RIGHT_BRACE, new PascalTokenTypeText("}")},
                {PascalTokenType.UP_ARROW, new PascalTokenTypeText("^")},
                {PascalTokenType.DOT_DOT, new PascalTokenTypeText("..")}
            };

        public static Hashtable SPECIAL_SYMBOLS = new Hashtable()
            {
                {new PascalTokenTypeText("+"),  PascalTokenType.PLUS},
                {new PascalTokenTypeText("-"),  PascalTokenType.MINUS},
                {new PascalTokenTypeText("*"),  PascalTokenType.STAR},
                {new PascalTokenTypeText("/"),  PascalTokenType.SLASH},
                {new PascalTokenTypeText(":="), PascalTokenType.COLON_EQUALS},
                {new PascalTokenTypeText("."),  PascalTokenType.DOT},
                {new PascalTokenTypeText(","),  PascalTokenType.COMMA},
                {new PascalTokenTypeText(";"),  PascalTokenType.SEMICOLON},
                {new PascalTokenTypeText(":"),  PascalTokenType.COLON},
                {new PascalTokenTypeText("'"),  PascalTokenType.QUOTE},
                {new PascalTokenTypeText("="),  PascalTokenType.EQUALS},
                {new PascalTokenTypeText("<>"), PascalTokenType.NOT_EQUALS},
                {new PascalTokenTypeText("<"),  PascalTokenType.LESS_THAN},
                {new PascalTokenTypeText("<="), PascalTokenType.LESS_EQUALS},
                {new PascalTokenTypeText(">="), PascalTokenType.GREATER_EQUALS},
                {new PascalTokenTypeText(">"),  PascalTokenType.GREATER_THAN},
                {new PascalTokenTypeText("("),  PascalTokenType.LEFT_PAREN},
                {new PascalTokenTypeText(")"),  PascalTokenType.RIGHT_PAREN},
                {new PascalTokenTypeText("["),  PascalTokenType.LEFT_BRACKET},
                {new PascalTokenTypeText("]"),  PascalTokenType.RIGHT_BRACKET},
                {new PascalTokenTypeText("{"),  PascalTokenType.LEFT_BRACE},
                {new PascalTokenTypeText("}"),  PascalTokenType.RIGHT_BRACE},
                {new PascalTokenTypeText("^"),  PascalTokenType.UP_ARROW},
                {new PascalTokenTypeText(".."), PascalTokenType.DOT_DOT}
            };

        private static PascalTokenTypeText GetPascalTokenTypeText(PascalTokenType type)
        {
            return SpecialSymbols[type];
        }

        public string getText()
        {
            return "0";
        }

        public class PascalTokenTypeText
        {
            public string text { get; private set; }

            public PascalTokenTypeText(string text)
            {
                this.text = text;
            }
        }
    }
}
