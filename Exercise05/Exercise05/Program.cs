using System;
using static System.IO.Path;
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

            string encryptionPassword = "121212";
            List<Customer> listOfEncryptedCustomers = new List<Customer> { };

            // Read unencrypted xml file
            using (FileStream fileStream = File.Open(xmlFilePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>), new XmlRootAttribute("customers"));
                List<Customer> customers = (List<Customer>)serializer.Deserialize(fileStream);

                foreach (Customer item in customers)
                {
                    listOfEncryptedCustomers.Add(new Customer() {
                        Name = item.Name,
                        CreditCard = Protector.Encrypt(item.CreditCard, encryptionPassword),
                        Password = Protector.SaltAndHashPassword(item.Password).SaltedHashedPassword
                    });
                }
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
