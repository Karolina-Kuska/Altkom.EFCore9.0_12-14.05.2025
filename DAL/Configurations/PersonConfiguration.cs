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

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(10);

            builder.Property(x => x.PESEL)
                //.HasColumnType("decimal(11,0)")
                .HasPrecision(11, 0);

            builder.Ignore(x => x.Address);

            builder.HasIndex(x => x.Name); //tworzy indeks na kolumnie Name
            builder.HasIndex(x => new { x.Name, x.LastName }).IsUnique(); //tworzy unikalny indeks złożony na kolumnach Name i LastName
        }
    }
}
