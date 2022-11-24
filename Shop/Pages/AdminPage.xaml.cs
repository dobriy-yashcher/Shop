using Microsoft.Win32;
using Shop.ADOApp;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private byte[] ImageItem { get; set; }
        private byte[] ImageRecipe { get; set; }

        public AdminPage()
        {
            InitializeComponent();
            AddRecipeFrame.NavigationService.Navigate(new AddRecipe());
            AddItemFrame.NavigationService.Navigate(new AddItemPage());
        }
    }
}