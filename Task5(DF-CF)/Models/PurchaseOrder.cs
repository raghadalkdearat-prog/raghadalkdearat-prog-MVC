using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task5_DF_CF_.Models;

public partial class PurchaseOrder
{
    [Key]
    public int PurchaseOrderId { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateOnly OrderDate { get; set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = null!;

    [Required]
    public int SupplierId { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        = new List<PurchaseOrderItem>();

    public virtual Supplier Supplier { get; set; } = null!;
}