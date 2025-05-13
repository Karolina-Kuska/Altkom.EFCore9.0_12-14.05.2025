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
    internal class CatConfiguration : IEntityTypeConfiguration<Cat>
    {
        public void Configure(EntityTypeBuilder<Cat> builder)
        {
        }
    }
}
