using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserWebAPI.Models;

namespace UserWebAPI.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x=> x.ID);
            builder.Property(x=>x.Mobile).IsRequired().HasMaxLength(11).IsFixedLength();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Email).IsRequired(false);
            builder.Property(x => x.FirstName).IsRequired(false);
            builder.Property(x => x.LastName).IsRequired(false);
            builder.Property(x => x.PictureUserPath).IsRequired(false);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.LastLoginDate).IsRequired(false);
        }
    }
}
