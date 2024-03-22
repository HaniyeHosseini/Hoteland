using Hoteland.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure.Repository.Interfaces
{
    public interface IFeatureRepository:IBaseRepository<Feature>
    {
        IList<Feature> GetFeaturesByHotelID(long  hotelID);
    }
}
