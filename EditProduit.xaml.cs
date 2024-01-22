using System;
using System.Net.Mime;
using System.Windows;
using LesDelicesDeTata.ViewModel;
namespace LesDelicesDeTata
{
    public partial class EditProduit : Window
{
    private ProduitViewModel _viewModel;

    public EditProduit(ProduitViewModel selectedProductViewModel)
    {
        InitializeComponent();
        _viewModel = selectedProductViewModel;

        if (_viewModel.SelectedProduit != null)
        {
            TextId.Text = _viewModel.SelectedProduit.id.ToString();
            TextNom.Text = _viewModel.SelectedProduit.Nom;
            TextDescription.Text = _viewModel.SelectedProduit.Description;
            TextPrix.Text = _viewModel.SelectedProduit.Prix.ToString();
            CategorieComboBox.SelectedItem = _viewModel.SelectedCategory;
        }

        DataContext = _viewModel;

        Console.WriteLine($"SelectedProduit in EditProduit constructor: {_viewModel.SelectedProduit}");
    }

    private void Enregistrer_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (_viewModel.SelectedProduit != null)
            {
                _viewModel.EditProduit(new Produits
                {
                    id = _viewModel.SelectedProduit.id,
                    Nom = TextNom.Text, 
                    Description = TextDescription.Text,
                    Prix = Convert.ToDecimal(TextPrix.Text)
                    
                });
                
                _viewModel.EditProduit(_viewModel.SelectedProduit);

                Close();
            }
            else
            {
                MessageBox.Show("Aucun produit sélectionné pour la modification.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de l'enregistrement des modifications : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

}