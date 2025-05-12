using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Animal
    {
        //[Key]
        public int Key { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }

    }
}
