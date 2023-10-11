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
            ServiceWP.Children.Clear();
            foreach (var service in serviceSortList)
            {
                ServiceWP.Children.Add(new ServicesUserControl(service));
            }
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }


}
