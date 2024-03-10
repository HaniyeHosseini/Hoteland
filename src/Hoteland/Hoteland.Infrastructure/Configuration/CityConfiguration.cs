using Hoteland.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.HasKey(x => x.ID);
            builder.HasOne(x => x.Country).WithMany(x => x.Cities).HasForeignKey(x => x.CountryID);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(x => x.Hotels).WithOne(x => x.City).HasForeignKey(x => x.CityID).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
