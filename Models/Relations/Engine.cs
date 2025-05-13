using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Relations
{
    public class Engine
    {
        public int Id { get; set; }
        public int Power { get; set; }

        public ICollection<Car> Cars { get; set; } = [];
    }
}
