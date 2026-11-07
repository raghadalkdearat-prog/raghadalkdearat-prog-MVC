namespace Task5_DF_CF_.Models.CodeFirst
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; } = null!;

        public string SupplierEmail { get; set; } = null!;

        public string SupplierPhone { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    }
}
