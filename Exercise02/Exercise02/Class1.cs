using System.Numerics;

namespace Exercise02
{
    public static class BigIntegerExtensions
    {
        public static string GenerateEndPart(BigInteger value, BigInteger divider)
        {
            BigInteger modulus = value % divider;
            string endPart = modulus == 0 ? "" : $"{(divider == 100 ? "and " : "")}{ConvertToWords(modulus)}";
            return endPart;
        }

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
                return $"{tensMultiple[(int)value / 10]} {(modulus == 0 ? "" : uniqueDigits[modulus])}";
            }

            // Hundred
            if (value < 1000)
            {
                int divider = 100;
                return $"{ConvertToWords(value / divider)} {tensPower[0]} {GenerateEndPart(value, divider)}";
            }

            // Thousand
            if (value < 1_000_000)
            {
                int divider = 1_000;
                return $"{ConvertToWords(value / divider)} {tensPower[1]} {GenerateEndPart(value, divider)}";
            }

            // Million
            if (value < 1_000_000_000)
            {
                int divider = 1_000_000;
                return $"{ConvertToWords(value / divider)} {tensPower[2]} {GenerateEndPart(value, divider)}";
            }

            // Billion
            if (value < 1_000_000_000_000)
            {
                int divider = 1_000_000_000;
                return $"{ConvertToWords(value / divider)} {tensPower[3]} {GenerateEndPart(value, divider)}";
            }

            // Trillion
            if (value < 1_000_000_000_000_000)
            {
                BigInteger divider = 1_000_000_000_000;
                return $"{ConvertToWords(value / divider)} {tensPower[4]} {GenerateEndPart(value, divider)}";
            }

            // Quadrillion
            if (value < 1_000_000_000_000_000_000)
            {
                BigInteger divider = 1_000_000_000_000_000;
                return $"{ConvertToWords(value / divider)} {tensPower[5]} {GenerateEndPart(value, divider)}";
            }

            // Quintillion
            if (value < 10_000_000_000_000_000_000)
            {
                BigInteger divider = 1_000_000_000_000_000_000;
                return $"{ConvertToWords(value / divider)} {tensPower[6]} {GenerateEndPart(value, divider)}";
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
