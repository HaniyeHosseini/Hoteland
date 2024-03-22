using Hoteland.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure.Repository.Interfaces
{
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        void AddPicturesToHotel(IList<HotelPicture> pictures);
        void AddFeaturesToHotel(IList<HotelFeature> features);
        IList<Hotel> GetHotelsWithPicturesAndFeatures();
        IList<HotelPicture> GetPicturesByHoteID(long hotelID);
    }
}
