using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise07
{
    [Serializable]
    public class Category
    {
        // these properties map to columns in the database 
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        // defines a navigation property for related rows
        public virtual List<Product> Products { get; set; }
        public Category()
        {
            // to enable developers to add products to a Category we must
            // initialize the navigation property to an empty collection 
            Products = new List<Product>();
        }
    }
}
