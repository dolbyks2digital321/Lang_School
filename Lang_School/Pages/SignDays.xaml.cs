using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Threading;

namespace Lang_School.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignDays.xaml
    /// </summary>
    public partial class SignDays : Page
    {
        DateTime endDate = DateTime.Now.AddDays(3);
        DispatcherTimer timer = new DispatcherTimer();
        public SignDays()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Update);
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();
            EntryList.ItemsSource = App.db.ClientService.Where(x => x.StartTime >= DateTime.Now && x.StartTime <= endDate).OrderBy(x => x.StartTime).ToList();
        }

        private void Update(object sender, EventArgs s)
        {
            EntryList.ItemsSource = App.db.ClientService.Where(x => x.StartTime >= DateTime.Now && x.StartTime <= endDate).OrderBy(x => x.StartTime).ToList();
        }
    }
}
