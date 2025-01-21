using System;
using System.Collections.Generic;

namespace SuperDemo_21_01_2025.Models;

public partial class Categoty
{
    public int CategotyId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Tovar> Tovars { get; set; } = new List<Tovar>();
}
