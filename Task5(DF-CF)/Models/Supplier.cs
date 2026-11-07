using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task5_DF_CF_.Models;

public partial class Supplier
{
    [Key]
    public int SupplierId { get; set; }

    [Required]
    [MaxLength(50)]
    public string SupplierName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string SupplierEmail { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string SupplierPhone { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; }
        = new List<Product>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        = new List<PurchaseOrder>();
}
