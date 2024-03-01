using Hoteland.Application.Contract.Place;
using Hoteland.Common;
using Hoteland.Domain.Models;
using Hoteland.Infrastructure.Repository.Implements;
using Hoteland.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.PlaceAgg
{
    public class CountryService : ICountryService
    {
        private readonly IPlaceRepository _placeRepository;

        public CountryService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public IList<CityDto> GetCitiesByCountryID(long CountryID)
        {
            var cities = _placeRepository.GetCitiesByCountryID(CountryID);
            var cityDtos = new List<CityDto>(cities.Count);
            foreach (var city in cities)
            {
                var cityDto = new CityDto();
                cityDto.ID = city.ID;
                cityDto.Name = city.Name;
                cityDto.Country = city.Country.Name;
                cityDtos.Add(cityDto);
            }
            return cityDtos;
        }

        public IList<CountryDto> GetCountries()
        {
            var countries = _placeRepository.GetCountries();
            var countryDtos = new List<CountryDto>(countries.Count);
            foreach (var country in countries)
            {
                var countryDto = new CountryDto();
                countryDto.ID = country.ID;
                countryDto.Name = country.Name;
                countryDtos.Add(countryDto);
            }
            return countryDtos;
        }

        public CountryDto GetCountryByID(long ID)
        {
            var country = _placeRepository.GetCountryByID(ID);
            if (country == null) return null;
            var countryDto = new CountryDto();
            countryDto.ID = country.ID;
            countryDto.Name = country.Name;
            return countryDto;
        }

        public OperationResult Insert(string name)
        {
            var op = new OperationResult();
            try
            {
                var country = new Country(name);
                _placeRepository.InsertCountry(country);
                op.Succeded();
                return op;
            }
            catch (Exception)
            {

                return op;
            }
           
        }

        public OperationResult Remove(long ID)
        {
            var op = new OperationResult();
            try
            {
                _placeRepository.RemoveCountry(ID);
                op.Succeded();
                return op;
            }
            catch (Exception)
            {
                return op;
            }
        }

        public OperationResult Update(string name, long ID)
        {
            var op = new OperationResult();
            try
            {
                var country = _placeRepository.GetCountryByID(ID);
                country.Name = name;
                country.LastUpdateDate = DateTime.Now;
                _placeRepository.UpdateCountry(country);
                op.Succeded();
                return op;
            }
            catch (Exception)
            {
                return op;
            }
        }
    }
}
