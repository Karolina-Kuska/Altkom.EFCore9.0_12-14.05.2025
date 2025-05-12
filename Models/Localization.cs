using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    //[PrimaryKey(nameof(Latitude), nameof(Longitude))]
    public class Localization
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
