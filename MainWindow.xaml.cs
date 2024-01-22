using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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
            string message =
                $"Image: {produit.Image}\nNom: {produit.Nom}\nPrix: {produit.Prix}€\nDescription: {produit.Description}";

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
                    // Now you can use the selected product for deletion
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

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is int produitId)
            {
                // Log la valeur de SelectedProduit avant d'ouvrir la fenêtre EditProduit
                Console.WriteLine($"SelectedProduit before EditProduit window: {_produitViewModel.SelectedProduit}");

                // Naviguer vers la page de modification en passant l'identifiant du produit sélectionné
                EditProduit editProduitWindow = new EditProduit();
                editProduitWindow.Show();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un produit à modifier.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine("ProduitId is null");
            }
        }





    }










}
