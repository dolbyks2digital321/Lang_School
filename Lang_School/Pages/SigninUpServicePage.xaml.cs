using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Schema;
using Lang_School.Components;

namespace Lang_School.Pages
{
    /// <summary>
    /// Логика взаимодействия для SigninUpServicePage.xaml
    /// </summary>
    public partial class SigninUpServicePage : Page
    {
        Service service;
        public SigninUpServicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
            ClientCbx.ItemsSource = App.db.Client.ToList();
            ClientCbx.DisplayMemberPath = "FullNameSet";
            DateDp.DisplayDateStart = DateTime.Now;
        }

        private bool isValidTime(string time)
        {
            string formatTime = @"\d{2}:\d{2}";
            if (Regex.IsMatch(time, formatTime)) return true;
            else return false;
        }

        private void SignUpButt_Click(object sender, RoutedEventArgs e)
        {
            if(DateDp.SelectedDate != null && !string.IsNullOrWhiteSpace (TimeTb.Text) && ClientCbx.SelectedItem != null)
            {
                var selDateTime = $"{DateDp.SelectedDate.Value.ToString("yyyy-MM-dd")} {TimeTb.Text}";
                if (DateTime.TryParse(selDateTime, out DateTime result))
                {
                    if (DateTime.Now < result)
                    {
                        var selectClient = ClientCbx.SelectedItem as Client;
                        App.db.ClientService.Add(new ClientService()
                        {
                            ClientID = selectClient.ID,
                            ServiceID = service.ID,
                            StartTime = result
                        });
                        MessageBox.Show("Запись добавлена");
                        App.db.SaveChanges();
                    }
                    else MessageBox.Show("Неверный формат времени!");
                }
                else MessageBox.Show("Неверный формат времени!");
            }
            else MessageBox.Show("Выберите дату!");
        }
    }
}
