using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task5_DF_CF_.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [MaxLength(50)]
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "decimal(10,2)")]
    [Range(0, double.MaxValue)]
    public decimal ProductPrice { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int SupplierId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        = new List<PurchaseOrderItem>();

    public virtual Supplier Supplier { get; set; } = null!;
}