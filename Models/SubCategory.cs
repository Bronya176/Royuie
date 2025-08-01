using System.Collections.Generic;
using royuie.Models;

namespace royuie.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Foreign key to category//
        public int CategoryId { get; set; }
        public Category Category { get; set; }



        //Each SubCategory has many products//
        public ICollection<Product> Products { get; set; }
    }
}