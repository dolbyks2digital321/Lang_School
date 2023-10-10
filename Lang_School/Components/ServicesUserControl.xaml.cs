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

namespace Lang_School.Components
{
    /// <summary>
    /// Логика взаимодействия для ServicesUserControl.xaml
    /// </summary>
    public partial class ServicesUserControl : UserControl
    {
        public ServicesUserControl(Service service)
        {
            InitializeComponent();
            TitleTb.Text = service.Title;
            CostTimeTb.Text = service.CostTimeStr;
            DiscoTb.Text = service.DiscountStr;
            CostTb.Text = service.Cost.ToString(CostTb.Text);
            CostTb.Visibility = service.CostVisibility;
        }
    }
}
