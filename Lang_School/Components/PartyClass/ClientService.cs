using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang_School.Components
{
    public partial class ClientService
    {
        public string TimeStart 
        { 
            get 
            { var time = StartTime - DateTime.Now;
                return $"{time.Hours * -1}:{time.Minutes * -1}"; } 
        }
    }
}
