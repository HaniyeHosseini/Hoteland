using Hoteland.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.Contract.Place
{
    public interface ICityService
    {
        OperationResult Insert(string name, long countryID);
        OperationResult Update(CityDto city);
        OperationResult Remove(long ID);
        CityDto GetCityByID(long ID);
        IList<CityDto> GetCitiesByCountryID(long countryID);
        IList<CityDto> GetCities();

    }
}
