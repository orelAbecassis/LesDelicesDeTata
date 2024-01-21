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
                // Récupérer la valeur du Tag depuis _viewModel.ProduitId
                object tagValue = _viewModel.ProduitId;
                    
                if (_viewModel.SelectedProduit != null)
                {
                    // Appeler la méthode appropriée dans votre ViewModel pour enregistrer les modifications
                    _viewModel.EditProduit(new Produits
                    {
                        // Supposons que ces propriétés existent dans votre ViewModel
                        id = _viewModel.SelectedProduit.id,
                        Nom = _viewModel.SelectedProduit.Nom,
                        Description = _viewModel.SelectedProduit.Description,
                        Prix = _viewModel.SelectedProduit.Prix
                        // Ajoutez d'autres propriétés au besoin
                    });

                    // Fermer la fenêtre après avoir enregistré les modifications
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