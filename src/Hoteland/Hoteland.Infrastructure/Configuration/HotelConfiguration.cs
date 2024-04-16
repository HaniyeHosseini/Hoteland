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
    internal class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotel");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Tell).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Location).IsRequired().HasColumnType("geography");
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.PictureAlt).IsRequired();
            builder.Property(x => x.PictureTitle).IsRequired();
            builder.Property(x=>x.CountryID).IsRequired(false);
            builder.Property(x => x.CityID).IsRequired(false);
            builder.HasOne(x => x.Country).WithMany(x => x.Hotels).HasForeignKey(x => x.CountryID).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Hotel_Country");
            builder.HasOne(x => x.City).WithMany(x => x.Hotels).HasForeignKey(x => x.CityID).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Hotel_City");
            builder.HasMany(x => x.Pictures).WithOne(x => x.Hotel).HasForeignKey(x => x.HotelID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Features).WithOne(x => x.Hotel).HasForeignKey(x => x.HotelID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
