using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using LesDelicesDeTata.Model;

namespace LesDelicesDeTata.ViewModel
{
    public class ProduitViewModel : ObservableObject
    {
        private DatabaseService _databaseService;
        private ObservableCollection<Produits> _allProduitsList;

        private ObservableCollection<Produits> _produits;
        public ObservableCollection<Produits> Produits
        {
            get { return _produits; }
            set { SetProperty(ref _produits, value, nameof(Produits)); }
        }

        private ObservableCollection<Categorie> _categorie;
        public ObservableCollection<Categorie> Categorie
        {
            get { return _categorie; }
            set { SetProperty(ref _categorie, value, nameof(Categorie)); }
        }

        private Categorie _selectedCategory;
        public Categorie SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                SetProperty(ref _selectedCategory, value, nameof(SelectedCategory));
                ToggleCategorySelection(SelectedCategory);
            }
        }

        private RelayCommand<Categorie> _toggleCategorySelectionCommand;
        public RelayCommand<Categorie> ToggleCategorySelectionCommand
        {
            get
            {
                return _toggleCategorySelectionCommand ?? (_toggleCategorySelectionCommand = new RelayCommand<Categorie>(ToggleCategorySelection));
            }
        }

        public ProduitViewModel()
        {
            _databaseService = new DatabaseService();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                // Chargez les films
                string produitQuery = "SELECT nom,  prix,description, image, id_categ_id FROM produits";
                DataTable produitResult = _databaseService.ExecuteQuery(produitQuery);

                // Chargez les catégories
                string categoryQuery = "SELECT id, nom_categ FROM categorie";
                DataTable categoryResult = _databaseService.ExecuteQuery(categoryQuery);

                if (produitResult.Rows.Count > 0)
                {
                    // Créer une liste de films
                    List<Produits> produits = new List<Produits>();
                   

                    // Parcourir toutes les lignes du résultat des films
                    foreach (DataRow row in produitResult.Rows)
                    {
                        // Créer un nouvel objet Produits et l'ajouter à la liste
                        produits.Add(new Produits
                        {
                            Nom = Convert.ToString(row["nom"]),
                            Prix = Convert.ToDecimal(row["prix"]),
                            Description = Convert.ToString(row["description"]),
                            Image = Convert.ToString(row["image"]),
                            idCategorie = Convert.ToInt32(row["id_categ_id"]),

                        });
                    }

                    // Assigner la liste de films à la propriété Films
                    Produits = new ObservableCollection<Produits>(produits);

                    // Assigner la liste complète des films à la propriété _allFilms
                    _allProduitsList = Produits;

                    // Afficher un message de réussite
                    Console.WriteLine("Données chargées avec succès depuis la base de données.");
                }
                else
                {
                    // Aucune donnée trouvée pour les films
                    MessageBox.Show("Aucune donnée trouvée dans la base de données pour les films.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (categoryResult.Rows.Count > 0)
                {
                    // Créer une liste de catégories
                    List<Categorie> categories = new List<Categorie>();

                    // Parcourir toutes les lignes du résultat des catégories
                    foreach (DataRow row in categoryResult.Rows)
                    {
                        // Créer une nouvelle catégorie et l'ajouter à la liste
                        categories.Add(new Categorie
                        {
                            CategorieId = Convert.ToInt32(row["id"]),
                            NomCateg = Convert.ToString(row["nom_categ"])
                        });
                    }

                    // Assigner la liste de catégories à la propriété Categories
                    Categorie = new ObservableCollection<Categorie>(categories);
                }
                else
                {
                    // Aucune donnée trouvée pour les catégories
                    MessageBox.Show("Aucune donnée trouvée dans la base de données pour les catégories.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Gérer les erreurs de connexion à la base de données
                MessageBox.Show($"Erreur de connexion à la base de données : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine($"Error in LoadData: {ex}");
            }
        }

        private void ToggleCategorySelection(Categorie clickedCategory)
        {
            // Inverser la sélection de la catégorie cliquée
            clickedCategory.IsSelected = !clickedCategory.IsSelected;

            // Filtrer la liste des produits en fonction des catégories sélectionnées
            var selectedCategories = Categorie.Where(c => c.IsSelected).ToList();

            if (selectedCategories.Count > 0)
            {
                var filteredProduits = _allProduitsList.Where(produit => selectedCategories.Any(category => produit.idCategorie == category.CategorieId)).ToList();
                Produits = new ObservableCollection<Produits>(filteredProduits);
            }
            else
            {
                // Si aucune catégorie n'est sélectionnée, réinitialiser la liste complète des produits
                Produits = _allProduitsList;
            }

            // Rafraîchir l'affichage
            RaisePropertyChanged(nameof(Produits));
        }
        
        public void AjouterProduit(string nom, string description, decimal prix, string image, int idCategorie)
        {
            Produits nouveauProduit = new Produits
            {
                Nom = nom,
                Description = description,
                Prix = prix,
                Image = image,
                idCategorie = idCategorie
            };

            Produits.Add(nouveauProduit);

            // Vous pouvez également retourner ou afficher quelque chose si nécessaire
            Console.WriteLine("Produit ajouté avec succès !");
        }
        

    }
}
