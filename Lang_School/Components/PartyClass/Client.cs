using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lang_School.Components
{
    public partial class Client
    {
        public string FullNameSet
        {
            get { return $"{LastName} {FirstName} {Patronymic}"; }
        }
    }
}
