using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    //NotMapped - nie mapujemy tej klasy do bazy danych mimo, że jest dodany DbSet w kontekście
    [NotMapped]
    public class Address
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
    }
}
