using Lang_School.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace Lang_School.Components
{
    /// <summary>
    /// Логика взаимодействия для ServicesUserControl.xaml
    /// </summary>
    public partial class ServicesUserControl : UserControl
    {
        private Service service;
        public ServicesUserControl(Service _service)
        {
            InitializeComponent();
            service = _service;
            TitleTb.Text = service.Title;
            CostTimeTb.Text = service.CostTimeStr;
            DiscoTb.Text = service.DiscountStr;
            CostTb.Text = service.Cost.ToString(CostTb.Text);
            CostTb.Visibility = service.CostVisibility;
            MainBorder.Background = service.ColorDisco;
            Img.Source = GetImageSources(service.MainImage);

            if (App.isAdmin == false)
            {
                DeleteButt.Visibility = Visibility.Hidden;
                EditButt.Visibility = Visibility.Hidden;
            }
        }

        private BitmapImage GetImageSources(byte[] byteImage)
        {
            if (service.MainImage != null)
            {
                MemoryStream byteStream = new MemoryStream(byteImage);
                BitmapImage image = new BitmapImage();
               image.BeginInit();
               image.StreamSource = byteStream;
               image.EndInit();
               return image;
            }
            return new BitmapImage(new Uri(@"\Resources\school_logo.png", UriKind.Relative));
            
        }

        private void EditButt_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Редактирование услуг", new AddEditServicePage(service)));
        }

        private void DeleteButt_Click(object sender, RoutedEventArgs e)
        {
            if (service.ClientService.Count != 0)
            {
                MessageBox.Show("Удаление запрещено");
            }
            else
            {
                App.db.Service.Remove(service);
                App.db.SaveChanges();
                MessageBox.Show("Удалено: " + service.Title);
                Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
            }
        }
    }
}
