using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MyContext : DbContext
    {
        private readonly string? _connectionString;

        //konstruktor z parametrem connectionString
        public MyContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        //konstruktor z parametrem DbContextOptions - do użycia z DI
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //jeśli nie skonfigurowano opcji, to dodajemy domyślną konfigurację na podstawie connectionString
            if (!optionsBuilder.IsConfigured && _connectionString is not null)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

    }
}
