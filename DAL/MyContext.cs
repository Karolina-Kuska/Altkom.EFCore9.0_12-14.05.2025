using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class MyContext : DbContext
    {
        private readonly string? _connectionString;


        public MyContext()
        {

        }

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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString ?? string.Empty);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<Person>().Property(x => x.Name).HasColumnName("FirstName");
            modelBuilder.Entity<Person>().Property(x => x.LastName).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Person>().Property(x => x.PESEL)
                //.HasColumnType("decimal(11,0)")
                .HasPrecision(11, 0);
            modelBuilder.Entity<Person>().Ignore(x => x.Address);*/

            //ręczna rejestracja konfiguracji dla poszczególnych klas
            //modelBuilder.ApplyConfiguration(new PersonConfiguration());
            //modelBuilder.ApplyConfiguration(new AddressConfiguration());

            //automatyczna rejestracja konfiguracji dla wszystkich klas implementujących IEntityTypeConfiguration we wskazanym assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyContext).Assembly);
        }


        //DbSet dla tabeli Person
        //public DbSet<Models.Person_> People2 { get; }
        //public DbSet<Models.Address_> Addresses { get; }

    }
}
