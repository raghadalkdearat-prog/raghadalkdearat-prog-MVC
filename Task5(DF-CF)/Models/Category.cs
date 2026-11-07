using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task5_DF_CF_.Models;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string CategoryName { get; set; } = null!;

    [MaxLength(150)]
    public string CategoryDescription { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}