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

namespace Lang_School.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (PassBx.Password == "0000")
            {
                App.isAdmin = true;
                MessageBox.Show("Здравстуйте! Вы вошли как администратор!");
                NavigationService.Navigate(new ServiceListPage());
            }
            else if (PassBx.Password != "" && PassBx.Password != "0000") MessageBox.Show("Неверный пароль!");
            else
            {
                MessageBox.Show("Здравстуйте! Вы вошли как пользователь!");
                NavigationService.Navigate(new ServiceListPage());
            }

        }
    }
}
