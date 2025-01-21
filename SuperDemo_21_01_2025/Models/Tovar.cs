using Avalonia.Media.Imaging;
using Avalonia.Media;
using System;
using System.Collections.Generic;

namespace SuperDemo_21_01_2025.Models;

public partial class Tovar
{
    public int TovarId { get; set; }

    public string Articгul { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int EdIzmerenia { get; set; }

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

    public virtual EdIzmerenium EdIzmereniaNavigation { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual Postavshic Postavshic { get; set; } = null!;

    public Bitmap image => Picture != null ? new Bitmap($"Assets//{Picture}") : new Bitmap($"Assets//picture.png");

    public SolidColorBrush Colors => Discount > 15 ? new SolidColorBrush(Color.Parse("#7fff00")) : new SolidColorBrush(Color.Parse("White"));

    public decimal Price2 => Price - (Price * Discount/100);
}
