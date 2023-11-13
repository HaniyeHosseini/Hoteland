using Hoteland.Domain.Models;
using Hoteland.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure.Repository.Implements
{
    public class FeatureRepository : BaseRepository<Feature>, IBaseRepository<Feature>
    {
        public FeatureRepository(HotelandContext context) : base(context)
        {
        }
    }
}
