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
    /// Логика взаимодействия для SignDays.xaml
    /// </summary>
    public partial class SignDays : Page
    {
        public SignDays()
        {
            InitializeComponent();
            var nextDate = DateTime.Today.AddDays(1);
            
            //EntryList.ItemsSource = App.db.ClientService.Where(x => x.StartTime.ToString("dd.MM.yyyy") == DateTime.Now.ToString("dd.MM.yyyy") || x.StartTime.ToString("dd.MM.yyyy") == nextDate.ToString("dd.MM.yyyy")).ToList();
            EntryList.ItemsSource = App.db.ClientService.ToList();

        }
    }
}
