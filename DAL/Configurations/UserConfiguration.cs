using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            /*builder.Property(x => x.UserType)
                .HasConversion(
                    x => x.ToString(),
                    x => Enum.Parse<UserType>(x)
                );*/

            /* builder.Property(x => x.UserType)
                 .HasConversion(new EnumToStringConverter<UserType>());*/

            builder.Property(x => x.UserType)
                .HasConversion<string>();

            builder.Property(x => x.Password)
                .HasConversion(
                    x => BCrypt.Net.BCrypt.HashPassword(x),
                    x => x
                );

        }
    }
}
