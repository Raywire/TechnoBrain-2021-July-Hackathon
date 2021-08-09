using System.Xml.Serialization;

namespace Exercise05
{
    [XmlType("customer")]
    public class Customer
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("creditcard")]
        public string CreditCard { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }
    }
}
