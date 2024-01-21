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
      
        private int _produitId;
        public int ProduitId
        {
            get { return _produitId; }
            set { SetProperty(ref _produitId, value, nameof(ProduitId)); }
        }
        
        private Produits _selectedProduit;
        public Produits SelectedProduit
        {
            get { return _selectedProduit; }
            set { SetProperty(ref _selectedProduit, value, nameof(SelectedProduit)); }
        }
        public void SelectProduit(Produits produit)
        {
            SelectedProduit = produit;
        }
        
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
        
        public void AddProduit(Produits nouveauProduit)
        {
            try
            {
                // Ajouter le nouveau produit à la base de données
                string insertQuery = $"INSERT INTO produits (nom, prix, description, image, id_categ_id) VALUES ('{nouveauProduit.Nom}', {nouveauProduit.Prix}, '{nouveauProduit.Description}', '{nouveauProduit.Image}', {nouveauProduit.idCategorie})";
                _databaseService.ExecuteQuery(insertQuery);

                // Actualiser la liste des produits
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du produit : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine($"Error in AjouterProduit: {ex}");
            }
        }
        
        public void EditProduit(Produits produitModifie)
        {
            try
            {
                // Mettre à jour le produit dans la base de données
                string updateQuery = $"UPDATE produits SET nom='{produitModifie.Nom}', prix={produitModifie.Prix}, description='{produitModifie.Description}', image='{produitModifie.Image}', id_categ_id={produitModifie.idCategorie} WHERE id={produitModifie.id }";
                _databaseService.ExecuteQuery(updateQuery);

                // Actualiser la liste des produits
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification du produit : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine($"Error in ModifierProduit: {ex}");
            }
        }
      
        public void DeleteProduit(Produits produit)
        {
            try
            {
                // Votre logique pour supprimer le produit
                if (produit != null)
                {
                    // Supprimer le produit dans la base de données
                    string deleteQuery = $"DELETE FROM produits WHERE id = {produit.id }";
                    _databaseService.ExecuteQuery(deleteQuery);

                    // Afficher un message de succès
                    MessageBoxResult result = MessageBox.Show("Le produit a été supprimé avec succès. Voulez-vous rafraîchir la liste des produits ?", "Succès", MessageBoxButton.YesNo, MessageBoxImage.Information);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Actualiser la liste des produits
                        LoadData();
                    }
                }
                else
                {
                    // Afficher un message d'erreur si le produit est null
                    MessageBox.Show("Veuillez sélectionner un produit à supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur en cas d'exception
                MessageBox.Show($"Erreur lors de la suppression du produit : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine($"Error in SupprimerProduit: {ex}");
            }
           
        }
        
        /*public void DeleteProduit(int id)
        {
            try
            {
                // Supprimer le produit dans la base de données
                string deleteQuery = $"DELETE FROM produits WHERE id = {id}";
                _databaseService.ExecuteQuery(deleteQuery);

                // Actualiser la liste des produits
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression du produit : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine($"Error in DeleteProduit: {ex}");
            }
        }*/

        
       


        

       
        
       


    }
}
