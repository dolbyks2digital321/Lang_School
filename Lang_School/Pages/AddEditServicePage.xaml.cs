using Lang_School.Components;
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
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        private Service service;
        public AddEditServicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
        }

        private void SaveButt_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (service.Cost < 0)
            {
                error.AppendLine("Услуга не может иметь такую цену!");
            }

            if (service.DurationInSeconds > 14400)
            {
                error.AppendLine("Услуга не может превышать 4 часа!");
            }
            
            // если у нас такого объекта нет, соответственно, ид = 0
            if (service.ID == 0)
            {
                //если совпадают названия, то выдаем ошибку
                if (App.db.Service.Any(X => X.Title == service.Title))
                {
                    error.AppendLine("Такая услуга уже существует!");
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    App.db.Service.Add(service);
                }
            }    
            //вывод ошибкок
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            App.db.SaveChanges();
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0)
            {
                e.Handled = true;
            }
        }
    }
}
