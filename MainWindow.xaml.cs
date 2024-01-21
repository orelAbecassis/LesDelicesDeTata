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
using System.Windows.Shapes;
using System.Windows;
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
    }
}
