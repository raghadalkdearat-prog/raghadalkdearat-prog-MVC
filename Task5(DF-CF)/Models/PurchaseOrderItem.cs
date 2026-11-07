using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task5_DF_CF_.Models;

public partial class PurchaseOrderItem
{
    [Key]
    public int PurchaseOrderItemId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    [Range(0, double.MaxValue)]
    public decimal UnitPrice { get; set; }

    [Required]
    public int PurchaseOrderId { get; set; }

    [Required]
    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}