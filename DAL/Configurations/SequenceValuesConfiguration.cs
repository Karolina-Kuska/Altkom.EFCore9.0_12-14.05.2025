using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    internal class SequenceValuesConfiguration : IEntityTypeConfiguration<SequenceValues>
    {
        public void Configure(EntityTypeBuilder<SequenceValues> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever(); //ustawia Id jako nie generowane automatycznie
            builder.Property(x => x.Id).HasDefaultValueSql("NEXT VALUE FOR CustomId"); //ustawia domyślną wartość Id na wartość z sekwencji CustomId
            builder.Property(x => x.Value).HasDefaultValueSql("NEXT VALUE FOR MySequence"); //ustawia domyślną wartość na kolejny element sekwencji MySequence
        }
    }
}
