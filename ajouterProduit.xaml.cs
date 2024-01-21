using System.Windows;

namespace LesDelicesDeTata;

public partial class ajouterProduit : Window
{
    public ajouterProduit()
    {
        InitializeComponent();
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

        // Appeler la méthode AjouterProduit de la classe GestionProduits
        /*
        ajouterProduit.Ajouter(nom, description, prix, image, 0); // Ici, 0 représente l'id de la catégorie, vous devez ajuster cela
        */

        // Fermer la fenêtre actuelle
        this.Close();
    }
}