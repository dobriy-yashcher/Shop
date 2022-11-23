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
    /// Логика взаимодействия для AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        public AuthoPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            EventLogin();
        }

        public void EventLogin()
        {
            try
            {
                if ((TxtLogin.Text != "") && (TxtPassword.Password != ""))
                {
                    var DataLogin = App.Connection.Authorization.Where(z => z.Login == TxtLogin.Text 
                                                        && z.Password == TxtPassword.Password).FirstOrDefault();

                    if (DataLogin != null)
                    {
                        if (App.Connection.User.Where(z => z.Id == DataLogin.User).FirstOrDefault().Role == 1) 
                            NavigationService.Navigate(new UserPage(DataLogin));

                        else NavigationService.Navigate(new AdminPage());
                    }

                    else MessageBox.Show("Неправильный логин или пароль");
                }

                else MessageBox.Show("Заполните поля!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                EventLogin();
        }
    }
}
