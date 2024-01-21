using System.Windows;
using LesDelicesDeTata.ViewModel;
using LesDelicesDeTata.Model;

namespace LesDelicesDeTata
{
    public partial class AjouterProduit : Window
    {
        private ProduitViewModel viewModel;

        public AjouterProduit()
        {
            InitializeComponent();
            viewModel = new ProduitViewModel(); // Initialisez le champ viewModel de niveau de classe
            categorieComboBox.ItemsSource = viewModel.Categorie;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les données saisies par l'utilisateur
            string nom = nomTextBox.Text;
            string description = descriptionTextBox.Text;

            // Gérer les erreurs de conversion
            if (!decimal.TryParse(prixTextBox.Text, out decimal prix))
            {
                MessageBox.Show("Veuillez saisir un prix valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string image = imageTextBox.Text;

            // Vérifier si un élément est sélectionné dans la ComboBox
            if (categorieComboBox.SelectedItem != null && categorieComboBox.SelectedItem is Categorie selectedCategory)
            {
                int idCategorie = selectedCategory.CategorieId;

                // Appeler la méthode AjouterProduit de la classe ProduitViewModel
                viewModel.AddProduit(new Produits
                {
                    Nom = nom,
                    Description = description,
                    Prix = prix,
                    Image = image,
                    idCategorie = idCategorie
                });
                viewModel.LoadData();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une catégorie.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Fermer la fenêtre actuelle
            this.Close();
        }
    }
}