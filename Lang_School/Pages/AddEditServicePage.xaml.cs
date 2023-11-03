using Lang_School.Components;
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
             PhotoList.ItemsSource = App.db.ServicePhoto.Where(x => x.ServiceID == service.ID).ToList();
            if (service.ID != 0) StackPanelPhoto.Visibility = Visibility.Visible;
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
                    StackPanelPhoto.Visibility = Visibility.Visible;
                }
            }    
            //вывод ошибкок
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            App.db.SaveChanges();
            MessageBox.Show("Сохранено!");
              
            //Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void EditImageButt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jepg|*.jepg"
            };
            if (openFile.ShowDialog() == true)
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }

        }

        private void AddImgButt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jepg|*.jepg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                App.db.ServicePhoto.Add(new ServicePhoto()
                {
                    ServiceID = service.ID,
                    PhotoByte = File.ReadAllBytes(openFile.FileName)
                });
                App.db.SaveChanges();
                PhotoList.ItemsSource = App.db.ServicePhoto.Where(x => x.ServiceID == service.ID).ToList();
            }
            else MessageBox.Show("Ничего не выбрано!");
        }

        private void DeleteImgButt_Click(object sender, RoutedEventArgs e)
        {
            var selectPhoto = PhotoList.SelectedItem as ServicePhoto;
            if (selectPhoto != null) 
                App.db.ServicePhoto.Remove(selectPhoto);
            else 
                MessageBox.Show("Ничего не выбрано!");
            App.db.SaveChanges();   
            PhotoList.ItemsSource = App.db.ServicePhoto.Where(x => x.ServiceID == service.ID).ToList();
        }
    }
}
