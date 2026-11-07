namespace Task5_DF_CF_.Models.CodeFirst
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }//Navigation Property
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
     
    }
}
