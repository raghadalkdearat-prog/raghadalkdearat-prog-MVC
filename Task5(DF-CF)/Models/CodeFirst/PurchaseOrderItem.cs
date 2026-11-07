namespace Task5_DF_CF_.Models.CodeFirst
{
    public class PurchaseOrderItem
    {
        public int PurchaseOrderItemId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int PurchaseOrderId { get; set; }
        public  PurchaseOrder PurchaseOrder { get; set; }
        public int ProductId { get; set; }

        public  Product Product { get; set; }

       
    }
}
