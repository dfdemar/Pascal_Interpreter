using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpreter.frontend.pascal.tokens
{
    public class PascalNumberToken : PascalToken
    {
        private static readonly int MAX_EXPONENT = 37;

        public PascalNumberToken(Source source) : base(source)
        {
        }

        protected void extract()
        {
            StringBuilder textBuffer = new StringBuilder(); // token's characters
            extractNumber(textBuffer);
            text = textBuffer.ToString();
        }

        // Extract a Pascal number token from the source.
        protected void extractNumber(StringBuilder textBuffer)
        {
            string wholeDigits = null; // digits before the decimal point
            string fractionDigits = null; // digits after the decimal point
            string exponentDigits = null; //exponent digits
            char exponentSign = '+'; // exponent sign '+' or '-'
            bool sawDotDot = false; // true if saw .. token
            char currentchar; // current character

            type = PascalTokenType.INTEGER; // assume INTEGER token type for now

            // Extract the digits of the whole part of the number.
            wholeDigits = unsignedIntegerDigits(textBuffer);
            if (type == PascalTokenType.ERROR)
                return;

            // Is there a . ?
            // It could be a decimal point or the start of a .. token
            currentchar = currentChar();
            if(currentchar == '.')
            {
                if (peekChar() == '.')
                    sawDotDot = true; // it's a ".." token, so don't consume it
                else
                {
                    type = PascalTokenType.REAL;
                    textBuffer.Append(currentchar);
                    currentchar = nextChar();

                    // Collect the digits of the fraction part of the number.
                    fractionDigits = unsignedIntegerDigits(textBuffer);
                    if (type == PascalTokenType.ERROR)
                    {
                        return;
                    }
                }
            }

            // Is there an exponent part?
            // There cannot be an exponent if we already saw a ".." token.
            currentchar = currentChar();

            if(!sawDotDot && ((currentchar == 'E') || (currentchar == 'e')))
            {
                type = PascalTokenType.REAL;  // exponent, so token type is REAL
                textBuffer.Append(currentchar);
                currentchar = nextChar();

                // exponent sign?
                if ((currentchar == '+') || (currentchar == '-'))
                {
                    textBuffer.Append(currentchar);
                    exponentSign = currentchar;
                    currentchar = nextChar();
                }

                // Extract the digits of the exponent.
                exponentDigits = unsignedIntegerDigits(textBuffer);
            }

            // Compute the value of an integer number token.
            if (type == PascalTokenType.INTEGER)
            {
                int integerValue = computeIntegerValue(wholeDigits);

                if (type != PascalTokenType.ERROR)
                    value = integerValue;
            }

            else if (type == PascalTokenType.REAL)
                float floatValue = computeFloatValue(wholeDigits, fractionDigits,
                                                 exponentDigits, exponentSign);
        }
    }
}
