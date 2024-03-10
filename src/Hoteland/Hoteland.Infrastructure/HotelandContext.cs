using Hoteland.Domain.Models;
using Hoteland.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure
{
    public class HotelandContext : DbContext
    {
        public HotelandContext(DbContextOptions<HotelandContext> options): base(options)
        {
        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public  DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelFeature> HotelFeatures { get; set; }
        public DbSet<HotelPicture> HotelPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(FeatureConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

    }
}
