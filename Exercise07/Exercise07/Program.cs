using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using static System.IO.Path;
using static System.Environment;
using System.Text.Json;

namespace Exercise07
{
    class Program
    {
        static void SerializeToXml(List<Category> categories)
        {
            string xmlFile = Combine(CurrentDirectory, "categories.xml");

            using (FileStream fileStream = File.Create(xmlFile))
            {
                XmlSerializer serializerXml = new XmlSerializer(typeof(List<Category>));
                serializerXml.Serialize(fileStream, categories);
            }
            Console.WriteLine("XML Serialization complete");
        }

        static void SerializeToJson(List<Category> categories)
        {
            string jsonFile = Combine(CurrentDirectory, "categories.json");

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(categories, options);
            File.WriteAllText(jsonFile, json);

            Console.WriteLine("JSON Serialization complete");
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                // a query to get all categories and their related products 
                IQueryable<Category> categories = db.Categories.Include(c => c.Products);

                // Serialize to XML
                SerializeToXml(categories.ToList());

                // Serialize to JSON
                SerializeToJson(categories.ToList());
            }
        }

        static void Main(string[] args)
        {
            QueryingCategories();
        }
    }
}
