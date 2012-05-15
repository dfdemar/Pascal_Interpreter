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

        protected override void extract()
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
            {
                float floatValue = computeFloatValue(wholeDigits, fractionDigits, exponentDigits, exponentSign);

                if (type != PascalTokenType.ERROR)
                    value = (float)floatValue;
            }

        }

        // Extract and return the digits of an unsigned integer
        private String unsignedIntegerDigits(StringBuilder textBuffer)
        {
            char currentchar = currentChar();

            // Must have at least one digit
            if (!Char.IsDigit(currentchar))
            {
                type = PascalTokenType.ERROR;
                value = PascalErrorCode.INVALID_NUMBER;
                return null;
            }

            // Extract the digits
            StringBuilder digits = new StringBuilder();
            while (Char.IsDigit(currentchar))
            {
                textBuffer.Append(currentchar);
                digits.Append(currentchar);
                currentchar = nextChar();
            }

            return digits.ToString();
        }

        // Compute and return the integer value of a string of digits.
        // Check for overflow.
        private int computeIntegerValue(String digits)
        {
            if (digits == null)
                return 0;

            int integerValue = 0;
            int previousValue = -1; // overflow occurred if previousValue > integerValue
            int index = 0;

            // Loop over the digits to compute the integer value as long
            // as there is no overflow
            while ((index < digits.Length) && (integerValue >= previousValue))
            {
                previousValue = integerValue;
                integerValue = 10 * integerValue + int.Parse(digits[index++].ToString());
            }

            // No overflow: Return the integer value
            if (integerValue >= previousValue)
                return integerValue;

            // Overflow:  Set the integer out of range error.
            else
            {
                type = PascalTokenType.ERROR;
                value = PascalErrorCode.RANGE_INTEGER;
                return 0;
            }
        }

        // Compute and return the float value of a real number.
        private float computeFloatValue(string wholeDigits, string fractionDigits, string exponentDigits, char exponentSign)
        {
            double floatValue = 0.0;
            int exponentValue = computeIntegerValue(exponentDigits);
            string digits = wholeDigits;

            // Negate the exponent if the exponent sign is '-'.
            if (exponentSign == '-')
                exponentValue = -exponentValue;

            // If there are any fraction digits, adjust the exponent value
            // and append the fraction digits.
            if (fractionDigits != null)
            {
                exponentValue -= fractionDigits.Length;
                digits += fractionDigits;
            }

            // Check for a real number out of range error.
            if (Math.Abs(exponentValue + wholeDigits.Length) > MAX_EXPONENT)
            {
                type = PascalTokenType.ERROR;
                value = PascalErrorCode.RANGE_REAL;
                return 0.0f;
            }

            // Loop over the digits to compute the float value.
            int index = 0;
            while(index < digits.Length)
                floatValue = 10 * floatValue + int.Parse(digits[index++].ToString());

            // Adjust the float value based on the exponent value.
            if (exponentValue != 0)
                floatValue *= Math.Pow(10, exponentValue);

            return (float)floatValue;
        }
    }
}
