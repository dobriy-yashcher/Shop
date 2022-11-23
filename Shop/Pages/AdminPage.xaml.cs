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
        public byte[] ImageMat { get; set; }

        public AdminPage()
        {
            InitializeComponent();
        }

        private void SaveMaterialClick(object sender, RoutedEventArgs e)
        {
            Item material = new Item
            {
                Name = tbName.Text,
                Image = ImageMat,
                Count = Convert.ToInt32(tbCount.Text),
                Cost = Convert.ToInt32(tbCost.Text)
            };

            App.Connection.Item.Add(material);
            App.Connection.SaveChanges();
        }

        private void ImageSelectionButtonClick(object sender, RoutedEventArgs e)
        {
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
            catch
            {
                MessageBox.Show("Только фото!", "Ошибка");
            }
        }
    }
}