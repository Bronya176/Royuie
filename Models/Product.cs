namespace royuie.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

        //Foreign key to SubCategory//
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

    }

}