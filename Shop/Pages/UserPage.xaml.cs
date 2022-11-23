using System;
using System.Collections.Generic;
using System.Linq;
using Shop.ADOApp;
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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public Authorization login;
        public List<Buscket> UsersBasket { get; set; }
        public List<Item> materialsList = new List<Item>();

        public UserPage(Authorization login)
        {
            this.login = login;

            InitializeComponent();
            
            ListOfMaterials.ItemsSource = App.Connection.Item.ToList();
            UsersBasket = App.Connection.Buscket.Where(x => x.Id == login.User).ToList();
            
            foreach (var item in UsersBasket)
            {
                materialsList.Add(App.Connection.Item.Where(x => x.Id == item.Item).FirstOrDefault());
            }

            UsersMaterials.ItemsSource = materialsList;
        }

        private void ListOfMaterialsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mat = ListOfMaterials.SelectedItem as Item;

            var newBuscket = new Buscket
            {
                Item = mat.Id,
                User = login.User,
            };

            App.Connection.Buscket.Add(newBuscket);
            App.Connection.SaveChanges();

            materialsList.Add(mat);
            UsersMaterials.Items.Refresh();
        }
    }
}