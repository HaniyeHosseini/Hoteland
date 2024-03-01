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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(x => x.ID);
            builder.HasMany(x => x.Cities).WithOne(x => x.Country).HasForeignKey(x => x.CountryID);
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
