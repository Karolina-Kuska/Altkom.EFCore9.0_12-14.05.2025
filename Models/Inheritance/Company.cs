using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Inheritance
{
    public class Company : AbstractCompany
    {
        public int NumberOfWorkers { get; set; }
    }
}
