using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LesDelicesDeTata.ViewModel;


namespace LesDelicesDeTata
{
    public partial class MainWindow : Window
    {
        private ProduitViewModel _produitViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _produitViewModel = new ProduitViewModel();
            DataContext = _produitViewModel; // Définir le contexte de données pour le DataContext
        }

        private void Produit_Click(object sender, MouseButtonEventArgs e)
        {
            var border = (Border)sender;
            var produit = (Produits)border.DataContext;

            // Construire le message à afficher
            string message = $@"<img src=""{produit.Image}"" alt=""{produit.Nom}"" />
                    <p>Nom: {produit.Nom}</p>
                    <p>Prix: {produit.Prix}€</p>
                    <p>Description: {produit.Description}</p>";

            // Afficher les détails du produit dans une boîte de dialogue
            MessageBox.Show(message, "Détails du Produit", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page addProduit
            AjouterProduit ajouterProduitWindow = new AjouterProduit();
            ajouterProduitWindow.Show();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var produit = button?.DataContext as Produits;

                if (produit != null)
                {
                    _produitViewModel.SelectProduit(produit);
                    _produitViewModel.DeleteProduit(produit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Supprimer_Click: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine($"Error in Supprimer_Click: {ex}");
            }
        }

        private void Modifier_Click(object sender,  RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var produit = button?.DataContext as Produits;

                if (produit != null)
                {
                    // Now you can use the selected product for deletion
                    _produitViewModel.SelectProduit(produit);
                    Console.WriteLine("on passeee");
                    EditProduit editProduitWindow = new EditProduit(_produitViewModel);
                    editProduitWindow.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Supprimer_Click: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine($"Error in Supprimer_Click: {ex}");
            }

        }






    }










}
