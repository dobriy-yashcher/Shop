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
        }

        private void SaveMaterialClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Item material = new Item
                {
                    Name = tbName.Text,
                    Image = ImageItem,
                    Count = Convert.ToInt32(tbCount.Text),
                    Cost = Convert.ToInt32(tbCost.Text)
                };

                App.Connection.Item.Add(material);
                App.Connection.SaveChanges();
            }
            catch { MessageBox.Show("Заполните поля!"); }
        }
        private void SaveRecipeClick(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Item material = new Item
            //    {
            //        Name = tbName.Text,
            //        Image = ImageItem,
            //        Count = Convert.ToInt32(tbCount.Text),
            //        Cost = Convert.ToInt32(tbCost.Text)
            //    };

            //    App.Connection.Item.Add(material);
            //    App.Connection.SaveChanges();
            //}
            //catch { MessageBox.Show("Заполните поля!"); }

        }

        private void ImageItemSelectionButtonClick(object sender, RoutedEventArgs e)
        {
            ImageItem = ImageSelect(sender);
        }
        private void ImageRecipeSelectionButtonClick(object sender, RoutedEventArgs e)
        {
            ImageRecipe = ImageSelect(sender);
        }

        private byte[] ImageSelect(object sender)
        {
            byte[] ImageMat = null;

            try
            {
                var btnSelect = sender as Button;
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() != null)
                {
                    ImageMat = File.ReadAllBytes(dialog.FileName);
                    btnSelect.Background = Brushes.Green;
                }

            }
            catch { MessageBox.Show("Только фото!", "Ошибка"); }
            
            return ImageMat;
        }

    }
}