using System;
using System.Collections.Generic;

namespace SuperDemo_21_01_2025.Models;

public partial class Tovar
{
    public int TovarId { get; set; }

    public string Articгul { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string EdIzmerenia { get; set; } = null!;

    public decimal Price { get; set; }

    public int MaxSkidka { get; set; }

    public int ManufacturerId { get; set; }

    public int PostavshicId { get; set; }

    public int CategotyId { get; set; }

    public int Discount { get; set; }

    public int Count { get; set; }

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public virtual Categoty Categoty { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual Postavshic Postavshic { get; set; } = null!;
}
