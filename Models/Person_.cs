using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    //EF Core automatycznie mapuje klasy do tabel w bazie danych
    //mamy wpływ na konfigurację mapowania poprzez definicje właściwości i adnotacje
    [Index(nameof(Name))] //tworzy indeks na kolumnie Name
    [Index(nameof(Name), nameof(LastName), IsUnique = true)] //tworzy unikalny indeks złożony na kolumnach Name i LastName
    public class Person_
    {
        public int Id { get; set; }

        [Column("FirstName")]
        public string? Name { get; set; }

        [MaxLength(10)]
        public string LastName { get; set; }
        [Range(1, 100)] //Adnotacja walidująca  po stronie programu a nie po stronie bazy danych
        public int Age { get; set; }
        [Column(TypeName = "decimal(11,0)")]
        public ulong PESEL { get; set; }

        //NotMapped - nie mapujemy tej właściwości/relacji do bazy danych
        [NotMapped]
        public Address_? Address { get; set; }
    }
}
