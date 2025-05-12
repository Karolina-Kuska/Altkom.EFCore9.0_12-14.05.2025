using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");

            builder.Property(x => x.Name).HasColumnName("FirstName");

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(10).HasDefaultValue("Unknown");

            builder.Property(x => x.PESEL)
                //.HasColumnType("decimal(11,0)")
                .HasPrecision(11, 0);

            builder.Ignore(x => x.Address);

            builder.HasIndex(x => x.Name); //tworzy indeks na kolumnie Name
            builder.HasIndex(x => new { x.Name, x.LastName }).IsUnique(); //tworzy unikalny indeks złożony na kolumnach Name i LastName
        
            builder.Property(x => x.Age).HasDefaultValue(18); //ustawia domyślną wartość na 18
            builder.Property(x => x.PESEL).HasDefaultValue(0);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()"); //ustawia domyślną wartość na aktualną datę i godzinę

            //builder.Property(x => x.FullName).HasComputedColumnSql("CONCAT(FirstName, ' ', LastName)"); //ustawia kolumnę FullName jako kolumnę obliczaną, która łączy Name i LastName
            builder.Property(x => x.FullName).HasComputedColumnSql("CONCAT(FirstName, ' ', LastName)", stored: true); //ustawia kolumnę FullName jako kolumnę obliczaną i składowaną, która łączy Name i LastName


            builder.Property(x => x.ModifiedAt)
                .HasComputedColumnSql("GETDATE()");

        }
    }
}
