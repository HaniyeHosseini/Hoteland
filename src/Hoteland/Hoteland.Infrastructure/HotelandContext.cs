using Hoteland.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
