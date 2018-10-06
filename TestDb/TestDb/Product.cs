using System.ComponentModel.DataAnnotations;

namespace TestDb
{
    class Product
    {
        [Key]
        public int ProdictId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
