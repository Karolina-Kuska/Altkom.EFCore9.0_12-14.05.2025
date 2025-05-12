using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    //EF Core automatycznie mapuje klasy do tabel w bazie danych
    //mamy wpływ na konfigurację mapowania poprzez definicje właściwości i adnotacje
    public class Person
    {
        public int Id { get; set; }

        [Column("FirstName")]
        public string? Name { get; set; }

        [MaxLength(10)]
        public string LastName { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }
        [Column(TypeName = "decimal(11,0)")]
        public ulong PESEL { get; set; }

        //NotMapped - nie mapujemy tej właściwości/relacji do bazy danych
        [NotMapped]
        public Address? Address { get; set; }
    }
}
