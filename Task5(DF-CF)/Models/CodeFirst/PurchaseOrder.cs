namespace Task5_DF_CF_.Models.CodeFirst
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        public DateOnly OrderDate { get; set; }

        public string Status { get; set; } = null!;

        public int SupplierId { get; set; }

        public  Supplier Supplier { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

        
    }
}

