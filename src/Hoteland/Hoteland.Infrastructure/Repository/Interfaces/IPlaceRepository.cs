using Hoteland.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Infrastructure.Repository.Interfaces
{
    public interface IPlaceRepository
    {
        void InsertCity(City city);
        void UpdateCity(City city);
        void RemoveCity(long ID);
        City GetCityByID(long ID);
        IList<City> GetCitiesByCountryID(long countryID);
        IList<City> GetCities();
        void InsertCountry(Country country);
        void UpdateCountry(Country country);
        void RemoveCountry(long ID);
        Country GetCountryByID(long ID);
        IList<Country> GetCountries();

    }
}
