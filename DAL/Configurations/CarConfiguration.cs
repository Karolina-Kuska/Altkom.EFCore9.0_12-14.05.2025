using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Relations;

namespace DAL.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {

            builder.HasOne(x => x.Registration).WithOne(x => x.Car).HasForeignKey<Car>("RegistrationId")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
