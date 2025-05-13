using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Inheritance;
using Models.Relations;

namespace DAL.Configurations
{
    internal class AbstractCompanyConfiguration : IEntityTypeConfiguration<AbstractCompany>
    {
        public void Configure(EntityTypeBuilder<AbstractCompany> builder)
        {
            builder.ToTable("Companies");


            //Dziedziczenie TPH - Table per Hierarchy - wykorzystuje jedną tabelę do przechowywania wszystkich danych
            //wymaga dodania kolumny dyskryminatora, która będzie przechowywała informację o typie obiektu

            //możemy zdefiniować kolumnę dyskryminatora, jeśli tego nie zrobimy EF sam ją doda
            builder.HasDiscriminator<int>("Type")
                .HasValue<Company>(100)
                .HasValue<SmallCompany>(3)
                .HasValue<LargeCompany>(0)
                //poinformowanie EF, że występuje więcej wartości dyskryminatorów niż jemu znane - wymusza dodawanie do zapytań filtrowania po dyskryminatorze
                //dzięki temu zamiast błędu otrzymujemy null
                .IsComplete(false);

            /*builder.HasDiscriminator<string>("Discriminator")
                .HasValue<Company>("Company")
                .HasValue<SmallCompany>("SmallCompany")
                .HasValue<LargeCompany>("LargeCompany")
                .IsComplete(false);*/

        }
    }
}
