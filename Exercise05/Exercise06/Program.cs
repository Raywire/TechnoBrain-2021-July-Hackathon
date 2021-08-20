using Exercise05;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using static System.IO.Path;

namespace Exercise06
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFileDirectory = (GetFullPath(@"..\..\..\..\Exercise05"));
            string xmlFilePath = Combine(xmlFileDirectory, "customers-encrypted.xml");

            string encryptionPassword = "121212";
            List<Customer> listOfUnencryptedCustomers = new List<Customer>();

            // Read encrypted xml file
            using (FileStream fileStream = File.Open(xmlFilePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>), new XmlRootAttribute("customers"));
                List<Customer> customers = (List<Customer>)serializer.Deserialize(fileStream);

                foreach (Customer item in customers)
                {
                    listOfUnencryptedCustomers.Add(new Customer()
                    {
                        Name = item.Name,
                        CreditCard = Protector.Decrypt(item.CreditCard, encryptionPassword),
                        Password = item.Password
                    });
                }
            }

            // Write to encrypted xml file
            string xmlFileEncryptedPath = Combine(GetFullPath(@"..\..\..\"), "customers-unencrypted.xml");

            using (XmlWriter xmlWriter = XmlWriter.Create(xmlFileEncryptedPath, new XmlWriterSettings { Indent = true, Encoding = System.Text.Encoding.UTF8 }))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("customers");
                foreach (Customer customer in listOfUnencryptedCustomers)
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

            Console.WriteLine("Decryption completed");
        }
    }
}
