using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend.pascal
{

    class WordAttribute: Attribute
    {
        public string text { get; private set; }

        internal WordAttribute(string text)
        {
            this.text = text;
        }
    }

    public class PascalTokenTypes
    {
        private static readonly int FIRST_RESERVED_INDEX = 0;
        private static readonly int LAST_RESERVED_INDEX = 34; // 35 total reserved words

        private static readonly int FIRST_SPECIAL_INDEX = 35;
        private static readonly int LAST_SPECIAL_INDEX = 58; // This is really sloppy. Doesn't seem like C# has an ordinal() method for enums.
                                                             // Need a better way to implement this.

        public static HashSet<string> RESERVED_WORDS = new HashSet<string>();
        public static Hashtable SPECIAL_SYMBOLS = new Hashtable();

        static PascalTokenTypes()
        {
            string[] values = Enum.GetNames(typeof(PascalTokenType));
            Attribute[] attributes = Attribute.GetCustomAttributes(typeof(WordAttribute));

            for (int i = FIRST_RESERVED_INDEX; i <= LAST_RESERVED_INDEX; ++i)
            {
                RESERVED_WORDS.Add(values[i].ToLower());
            }

            for (int i = FIRST_SPECIAL_INDEX; i <= LAST_SPECIAL_INDEX; ++i) 
            {
                SPECIAL_SYMBOLS.Add(attributes[i].ToString(), values[i]);
            }
        }
    }

    public enum PascalTokenType
    {
        // RESERVED WORDS
        AND, ARRAY, BEGIN, CASE, CONST, DIV, DO, DOWNTO, ELSE, END,
        FILE, FOR, FUNCTION, GOTO, IF, IN, LABEL, MOD, NIL, NOT,
        OF, OR, PACKED, PROCEDURE, PROGRAM, RECORD, REPEAT, SET,
        THEN, TO, TYPE, UNTIL, VAR, WHILE, WITH,

        // SPECIAL SYMBOLS
        [WordAttribute("+")]  PLUS,
        [WordAttribute("-")]  MINUS,
        [WordAttribute("*")]  STAR,
        [WordAttribute("/")]  SLASH,
        [WordAttribute(":=")] COLON_EQUALS,
        [WordAttribute(".")]  DOT,
        [WordAttribute(",")]  COMMA,
        [WordAttribute(";")]  SEMICOLON,
        [WordAttribute(":")]  COLON,
        [WordAttribute("'")]  QUOTE,
        [WordAttribute("=")]  EQUALS,
        [WordAttribute("<>")] NOT_EQUALS,
        [WordAttribute("<")]  LESS_THAN,
        [WordAttribute("<=")] LESS_EQUALS,
        [WordAttribute("<=")] GREATER_EQUALS,
        [WordAttribute(">")]  GREATER_THAN,
        [WordAttribute("(")]  LEFT_PAREN,
        [WordAttribute(")")]  RIGHT_PAREN,
        [WordAttribute("[")]  LEFT_BRACKET,
        [WordAttribute("]")]  RIGHT_BRACKET,
        [WordAttribute("{")]  LEFT_BRACE,
        [WordAttribute("}")]  RIGHT_BRACE,
        [WordAttribute("^")]  UP_ARROW,
        [WordAttribute("..")] DOT_DOT,

        IDENTIFIER, INTEGER, REAL, STRING,
        ERROR, END_OF_FILE
    }
}
