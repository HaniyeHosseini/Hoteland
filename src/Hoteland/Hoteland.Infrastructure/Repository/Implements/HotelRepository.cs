using EFCore.BulkExtensions;
using Hoteland.Domain.Models;
using Hoteland.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure.Repository.Implements
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        private readonly HotelandContext _context;

        public HotelRepository(HotelandContext context) : base(context)
        {

            _context = context;
        }

        public void AddFeaturesToHotel(IList<HotelFeature> features)
        {
            _context.BulkInsert(features);
        }

        public void AddPicturesToHotel(IList<HotelPicture> pictures)
        {
            _context.BulkInsert(pictures);
        }

        public IList<Hotel> GetHotelsWithPicturesAndFeatures()
        {
            return _context.Hotels.Include(x=>x.Pictures).Include(x=>x.Features).ToList();
        }

        public IList<HotelPicture> GetPicturesByHoteID(long hotelID)
        {
            return _context.HotelPictures.Where(x=>x.HotelID == hotelID).ToList(); 
        }
    }
}