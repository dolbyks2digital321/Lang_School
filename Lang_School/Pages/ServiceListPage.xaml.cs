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
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            if (App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            var serviceList = App.db.Service.ToList();

            Refresh();
        }

        private void Refresh()
        {
            IEnumerable<Service> serviceSortList = App.db.Service;
            if (SortCB.SelectedIndex == 1)
            {
                serviceSortList = serviceSortList.OrderBy(x => x.CostDiscount);
            }
            else if (SortCB.SelectedIndex == 2)
            {
                serviceSortList = serviceSortList.OrderByDescending(x => x.CostDiscount);
            }

            if(DiscountFilterCbx.SelectedIndex != 0)
            {
                if (DiscountFilterCbx.SelectedIndex == 1)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 0 && x.Discount < 5);
                if (DiscountFilterCbx.SelectedIndex == 2)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 5 && x.Discount < 15);
                if (DiscountFilterCbx.SelectedIndex == 3)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 15 && x.Discount < 30);
                if (DiscountFilterCbx.SelectedIndex == 4)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 30 && x.Discount < 70);
                if (DiscountFilterCbx.SelectedIndex == 5)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 70 && x.Discount < 100);
            }
            if (SearchTbx.Text != null)
            {
                serviceSortList = serviceSortList.Where(x => x.Title.ToLower().Contains(SearchTbx.Text.ToLower()) || x.Description.ToLower().Contains(SearchTbx.Text.ToLower()));
            }

            ServiceWP.Children.Clear();
            foreach (var service in serviceSortList)
            {
                ServiceWP.Children.Add(new ServicesUserControl(service));
            }
            CountDataTbx.Text = serviceSortList.Count() + " из " + App.db.Service.Count();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void DiscountFilterCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Добавление услуг", new AddEditServicePage(new Service())));
        }

        private void ZapisBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Ближайшие записи", new SignDays()));
        }
    }


}
