using System;
using static System.IO.Path;
using static System.Environment;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

namespace Exercise05
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFileDirectory = (GetFullPath(@"..\..\..\"));
            string xmlFilePath = Combine(xmlFileDirectory, "customers.xml");

            var exists = File.Exists(xmlFilePath);
            if (!exists)
            {
                Console.WriteLine("File does not exist");
                return;
            }

            string encryptionPassword = "121212";
            var listOfEncryptedCustomers = new List<Customer> { };

            //Read unencrypted xml file
            var doc = new XmlDocument();
            doc.Load(xmlFilePath);

            var root = doc.DocumentElement;
            if (root == null)
                return;

            var customers = root.SelectNodes("customer");
            if (customers == null)
                return;

            foreach (XmlNode customer in customers)
            {
                var name = customer.SelectSingleNode("name").InnerText;
                var creditcard = customer.SelectSingleNode("creditcard").InnerText;
                var password = customer.SelectSingleNode("password").InnerText;
                listOfEncryptedCustomers.Add(
                    new Customer()
                    {
                        Name = name,
                        CreditCard = Protector.Encrypt(creditcard, encryptionPassword),
                        Password = Protector.SaltAndHashPassword(password).SaltedHashedPassword
                    });
            }

            // Write to encrypted xml file
            string xmlFileEncryptedPath = Combine(xmlFileDirectory, "customers-encrypted.xml");

            using (XmlWriter xmlWriter = XmlWriter.Create(xmlFileEncryptedPath, new XmlWriterSettings { Indent = true, Encoding = System.Text.Encoding.UTF8 }))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("customers");
                foreach (Customer customer in listOfEncryptedCustomers)
                {
                    xmlWriter.WriteStartElement("customer");
                    xmlWriter.WriteElementString("name", customer.Name);
                    xmlWriter.WriteElementString("creditcard", customer.CreditCard);
                    xmlWriter.WriteElementString("password", customer.Password);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }

            Console.WriteLine("Encryption completed");
        }
    }
}
