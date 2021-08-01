using System;
using System.Numerics;

namespace Exercise02
{
    public static class BigIntegerExtensions
    {
        public static string ConvertToWords(BigInteger value) 
        {
            //var bigIntegerLength = value.Length;

            string[] uniqueDigits = new string[] {
                "zero", "one", "two", "three", "four",
                "five", "six", "seven", "eight", "nine",
                "ten", "eleven", "twelve",
                "thirteen",  "fourteen", "fifteen", "sixteen",
                "seventeen", "eighteen", "nineteen"
            };

            string[] tensMultiple = new string[] {
                "", "", "twenty",  "thirty", "forty",
                "fifty", "sixty", "seventy", "eighty", "ninety"
            };

            string[] tensPower
                = new string[] { "hundred", "thousand" };

            if (value < 20)
            {
                return uniqueDigits[(int)value];
            }

            // TODO: Add code to parse numbers over 20 here
            return $"big integer in words {value}";
        }
        public static string ToWords(this BigInteger bigInteger)
        {
            return ConvertToWords(bigInteger);
        }
    }
}
