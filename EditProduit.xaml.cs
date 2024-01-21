using System.Windows;
using LesDelicesDeTata.ViewModel;

namespace LesDelicesDeTata;



public partial class EditProduit : Window
{
    public EditProduit()
    {
        InitializeComponent();
        // Créer le ViewModel et associer le produit à modifier
        ProduitViewModel viewModel = new ProduitViewModel();
        /*
        ProduitViewModel.Produit = produit;
        */
        DataContext = viewModel;
    }
}