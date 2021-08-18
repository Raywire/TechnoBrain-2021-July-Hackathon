using System.Numerics;

namespace Exercise02
{
    public static class BigIntegerExtensions
    {
        public static string ConvertToWords(BigInteger value) 
        {
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

            string[] tensPower = new string[] { 
                "hundred", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion"
            };
            if (value < 0)
            {
                value *= -1; 
            }

            if (value < 20)
            {
                return uniqueDigits[(int)value];
            }

            if (value < 100)
            {
                int modulus = (int)value % 10;
                return $"{tensMultiple[((int)value / 10)]} {(modulus == 0 ? "" : uniqueDigits[modulus])}";
            }

            // Hundred
            if (value < 1000)
            {
                int modulus = (int)value % 100;
                string endPart = modulus == 0 ? "" : $"and {ConvertToWords(modulus)}";
                return $"{uniqueDigits[((int)value / 100)]} {tensPower[0]} {endPart}";
            }

            // Thousand
            if (value < 1_000_000)
            {
                int modulus = (int)value % 1_000;
                string endPart = modulus == 0 ? "" : $"{ConvertToWords(modulus)}";
                return $"{ConvertToWords((int)value / 1_000)} {tensPower[1]} {endPart}";
            }

            // Million
            if (value < 1_000_000_000)
            {
                int modulus = (int)value % 1_000_000;
                string endPart = modulus == 0 ? "" : $"{ConvertToWords(modulus)}";
                return $"{ConvertToWords((int)value / 1_000_000)} {tensPower[2]} {endPart}";
            }

            // Billion
            if (value < 1_000_000_000_000)
            {
                BigInteger modulus = value % 1_000_000_000;
                string endPart = modulus == 0 ? "" : $"{ConvertToWords(modulus)}";
                return $"{ConvertToWords(value / 1_000_000_000)} {tensPower[3]} {endPart}";
            }

            // Trillion
            if (value < 1_000_000_000_000_000)
            {
                BigInteger modulus = value % 1_000_000_000_000;
                string endPart = modulus == 0 ? "" : $"{ConvertToWords(modulus)}";
                return $"{ConvertToWords(value / 1_000_000_000_000)} {tensPower[4]} {endPart}";
            }

            // Quadrillion
            if (value < 1_000_000_000_000_000_000)
            {
                BigInteger modulus = value % 1_000_000_000_000_000;
                string endPart = modulus == 0 ? "" : $"{ConvertToWords(modulus)}";
                return $"{ConvertToWords(value / 1_000_000_000_000_000)} {tensPower[5]} {endPart}";
            }

            // Quintillion
            if (value < 10_000_000_000_000_000_000)
            {
                BigInteger modulus = value % 1_000_000_000_000_000_000;
                string endPart = modulus == 0 ? "" : $"{ConvertToWords(modulus)}";
                return $"{ConvertToWords(value / 1_000_000_000_000_000_000)} {tensPower[6]} {endPart}";
            }

            // TODO: Add code to parse numbers over 1_000_000_000_000_000_000 here
            return $"{value} is not supported";
        }
        public static string ToWords(this BigInteger bigInteger)
        {
            return ConvertToWords(bigInteger);
        }

        public static string ToWords(this int integer)
        {
            return ConvertToWords(integer);
        }
    }
}
