using Exercise07;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise08
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Northwind();
            Console.WriteLine("Enter the name of a city:");
            Console.WriteLine("The available cities with customers are:");
            List<string> cities = db.Customers.OrderByDescending(c => c.City).Select(c => c.City).Distinct().ToList();
            Console.WriteLine(string.Join(", ", cities));
            string city = Console.ReadLine();

            IQueryable<Customer> query = db.Customers.Where(c => c.City == city);
            int count = query.Count();

            Console.WriteLine($"There {(count == 1 ? "is" : "are")} {count} {(count == 1 ? "customer" : "customers")} in {city}:");
            foreach (Customer item in query)
            {
                Console.WriteLine($"{item.CompanyName}");
            }
        }
    }
}
