using Exercise02;
using System;
using System.Numerics;

namespace Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("Input a number to be displayed in words:");
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (BigInteger.TryParse(input, out BigInteger bigInteger))
                    {
                        var toWords = bigInteger.ToWords();
                        Console.WriteLine($"Your number in words is: {toWords}");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input");
                    }

                }
                else
                {
                    Console.WriteLine("Please enter a valid input");
                }
                Console.WriteLine("Press ESC to end or any key to try again.");
                cki = Console.ReadKey();
                Console.WriteLine();
            } while (cki.Key != ConsoleKey.Escape);

        }
    }
}
