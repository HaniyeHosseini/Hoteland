using Hoteland.Domain.Models;
using Hoteland.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure.Repository.Implements
{
    public class FeatureRepository : BaseRepository<Feature>, IBaseRepository<Feature> , IFeatureRepository
    {
        private readonly HotelandContext _context;
        public FeatureRepository(HotelandContext context) : base(context)
        {
            _context = context;
        }

        public IList<Feature> GetFeaturesByHotelID(long hotelID)
        {
            return _context.HotelFeatures.Where(x=>x.HotelID== hotelID).Select(x=>x.Feature).ToList();
        }
    }
}
