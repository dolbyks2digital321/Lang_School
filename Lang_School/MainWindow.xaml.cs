using System;
using System.IO;
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
using Lang_School.Pages;

namespace Lang_School
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var path = @"\\NAS36D451\user-domain$\stud\212115\Desktop\";
            //foreach(var item in App.db.Service.ToArray())
            //{
            //    var fullPath = path + item.MainImage_Path.Trim();
            //    item.MainImage = File.ReadAllBytes(fullPath);
            //}
            //App.db.SaveChanges();
            MainFrame.Navigate(new AuthorizationPage());
        }

        private void BackButt_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack && App.isAdmin == true)
            {
                MainFrame.GoBack();
                MainFrame.RemoveBackEntry();
            }
            else if (MainFrame.CanGoBack) MainFrame.GoBack();      
        }

        private void ExitButt_Click(object sender, RoutedEventArgs e)
        {
            App.isAdmin = false;
            MainFrame.Navigate(new AuthorizationPage());
            if (MainFrame.CanGoBack) MainFrame.RemoveBackEntry();
        }
    }
}