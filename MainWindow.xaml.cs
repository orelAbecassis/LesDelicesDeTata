﻿using System;
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
            string message = $"Image: {produit.Image}\nNom: {produit.Nom}\nPrix: {produit.Prix}€\nDescription: {produit.Description}";

            // Afficher les détails du produit dans une boîte de dialogue
            MessageBox.Show(message, "Détails du Produit", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Naviguer vers la page addProduit
            AjouterProduit ajouterProduitWindow = new AjouterProduit();
            ajouterProduitWindow.Show();
        }


        







    }
}
