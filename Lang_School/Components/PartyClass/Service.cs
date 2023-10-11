using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Lang_School.Components
{
    public partial class Service
    {
        public string CostTimeStr
        {
            get
            {
                if (Discount == 0) return $"{Cost} рублей за {DurationInSeconds /60} минут";
                else return $"{CostDiscount} рублей за {DurationInSeconds / 60} минут";
            }
            set { }
        }

        public Visibility CostVisibility
        {
            get
            {
                if (Discount == 0)
                    return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }

        public string DiscountStr
        {
            get
            {
                if (Discount == 0)
                    return "";
                else
                    return $"скидка {Discount}%";
            }
        }

        public SolidColorBrush ColorDisco
        {
            get
            {
                if (Discount == 0)
                    return new SolidColorBrush(Color.FromRgb(255,255,255));
                else return new SolidColorBrush(Color.FromRgb(231, 250, 191));
            }
        }    

        public decimal CostDiscount
        {
            get 
            {
                if (Discount == 0)
                    return Cost;
                else return Cost - (Cost = (decimal)Discount / 100);
            }
        }
    }
}
