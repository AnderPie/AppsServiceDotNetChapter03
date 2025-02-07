using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Models;

[Index("CategoryName", Name = "CategoryName")]

// Category is partial so that you can add your own Category class, and if you re-run the scaffolding tool it doesn't overwrite ur class
public partial class Category //Humanizer third-party package automatically replaces the Categories table name with Category. Neat!
{
    [Key] // Explicitly indicate CategoryId is key
    public int CategoryId { get; set; }

    [StringLength(15)]
    public string CategoryName { get; set; } = null!;

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Picture { get; set; }

    [InverseProperty("Category")] // Identifies the foreign key on the Product entity class
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
