using Microsoft.Win32;
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
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Page
    {
        private byte[] ImageRecipe { get; set; }

        public AddRecipe()
        {
            InitializeComponent();
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
