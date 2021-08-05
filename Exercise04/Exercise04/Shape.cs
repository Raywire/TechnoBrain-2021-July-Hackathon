using System.Xml.Serialization;

namespace Exercise04
{
    [XmlInclude(typeof(Circle)), XmlInclude(typeof(Rectangle))]
    public class Shape
    {
        public double Area
        {
            get
            {
                return GetArea();
            }
        }
        public string Colour { get; set; }

        public virtual double GetArea ()
        {
            return 0;
        }
    }
}
