namespace LesDelicesDeTata.ViewModel
{
    public class Categorie : ObservableObject
    {
        private bool _isSelected;

        public int CategorieId { get; set; }
        public string NomCateg { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value, nameof(IsSelected)); }
        }
    }
}