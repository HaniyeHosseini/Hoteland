using Hoteland.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteland.Domain.Models;
namespace Hoteland.Application.Contract.FeatureAgg
{
    public interface IFeatureServices
    {
        OperationResult Insert(string name, string picture);
        OperationResult Update(string name, string picture, long ID);
        OperationResult Remove(long ID);
        IList<FeatureDto> GetFeatures();
        IList<FeatureDto> GetFeaturesByHotelID(long hotelID);
        IList<HotelFeature> CreateFeatures(IList<FeatureDto> features);
        FeatureDto GetFeatureByID(long ID);
    }
}
