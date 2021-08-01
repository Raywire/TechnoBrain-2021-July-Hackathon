using System;
using System.Text.RegularExpressions;

namespace Exercise01
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            string pattern;
            do
            {
                Console.WriteLine("Enter a regular expression (or press ENTER to use the default): ^[a-z]+$");
                pattern = Console.ReadLine();
                Console.WriteLine("Enter some input:");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(pattern))
                {
                    pattern = @"^[a-z]+$";
                    Regex regex = new Regex(pattern);
                    bool match = regex.IsMatch(input);
                    Console.WriteLine($"{input} matches {regex}? {match}");
                }
                else
                {
                    Regex regex = new Regex(@pattern);
                    bool match = regex.IsMatch(input);
                    Console.WriteLine($"{input} matches {regex}? {match}");
                }
                Console.WriteLine("Press ESC to end or any key to try again.");
                cki = Console.ReadKey();
                Console.WriteLine();
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
