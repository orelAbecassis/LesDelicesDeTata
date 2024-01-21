using System;

namespace LesDelicesDeTata.ViewModel;

public class Produits
{
    public string Nom { get; set; }
    public string Description { get; set; }
    public decimal Prix { get; set; }
    public Uri ImageUri => new Uri(Image);
    public string Image { get; set; }
    public int idCategorie{ get; set; }
}