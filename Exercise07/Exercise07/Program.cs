using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using static System.IO.Path;
using static System.Environment;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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

        static void SerializeToBinary(List<Category> categories)
        {
            string binaryFile = Combine(CurrentDirectory, "categories.dat");

            using (FileStream fileStream = File.Create(binaryFile))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fileStream, categories);
                    Console.WriteLine("Binary Serialization complete");
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }
            }
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

                // Serialize to Binary
                SerializeToBinary(categories.ToList());
            }
        }

        static void Main(string[] args)
        {
            QueryingCategories();
        }
    }
}
