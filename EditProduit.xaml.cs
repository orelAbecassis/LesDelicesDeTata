using System;
using System.Windows;
using LesDelicesDeTata.ViewModel;
namespace LesDelicesDeTata
{
    public partial class EditProduit : Window
    {
        // Assuming you have a ViewModel property in your code-behind
        private ProduitViewModel _viewModel;

        public EditProduit()
        {
            InitializeComponent();
            // Instantiate your ViewModel
            _viewModel = new ProduitViewModel();
            // Set the DataContext of the window to the ViewModel
            DataContext = _viewModel;
            
            Console.WriteLine($"SelectedProduit in EditProduit constructor: {_viewModel.SelectedProduit}");

        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_viewModel.SelectedProduit != null)
                {
                    // Call the appropriate method in your ViewModel to save changes
                    _viewModel.EditProduit(new Produits
                    {
                        // Assuming these properties exist in your ViewModel
                        id = _viewModel.SelectedProduit.id,
                        Nom = _viewModel.SelectedProduit.Nom,
                        Description = _viewModel.SelectedProduit.Description,
                        Prix = _viewModel.SelectedProduit.Prix
                        // Add other properties as needed
                    });

                    // Close the window after saving changes
                    Close();
                }
                else
                {
                    MessageBox.Show("Aucun produit sélectionné pour la modification.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving changes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}