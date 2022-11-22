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

namespace Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((TxtLogin.Text != "") && (TxtName.Text != "") && (TxtPassword.Text != "") && (TxtRepeatPassword.Text != "") && (CBRole.SelectedItem != null))
                {
                    if (App.Connection.Authorization.Where(z => z.Login == TxtLogin.Text).FirstOrDefault() == null)
                    {
                        if (TxtPassword.Text == TxtRepeatPassword.Text)
                        {

                            User NewUser = new User() { Name = TxtName.Text };

                            if (CBRole.SelectedItem == "Admin") NewUser.Role = 2;
                            else NewUser.Role = 1;

                            App.Connection.User.Add(NewUser);
                            App.Connection.SaveChanges();

                            Authorization NewAuthorization = new Authorization()
                            {
                                Login = TxtLogin.Text,
                                Password = TxtPassword.Text,
                                User = App.Connection.User.Last().Id
                            };
                            App.Connection.Authorization.Add(NewAuthorization);
                            App.Connection.SaveChanges();

                            NavigationService.GoBack();
                            MessageBox.Show("Успешно!");
                        }
                        else MessageBox.Show("Пароли не совпали!");
                    }
                    else MessageBox.Show("Такой логин уже существует!");
                }
                else MessageBox.Show("Заполните поля!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}