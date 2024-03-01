using Hoteland.Application.Contract.Place;
using Hoteland.Common;
using Hoteland.Domain.Models;
using Hoteland.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.PlaceAgg
{
    public class CityService : ICityService
    {
        private readonly IPlaceRepository _placeRepository;

        public CityService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public IList<CityDto> GetCities()
        {
           var cities = _placeRepository.GetCities();
            var cityDtos = new List<CityDto>();
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
        public IList<CityDto> GetCitiesByCountryID(long countryID)
        {
            var cities = _placeRepository.GetCitiesByCountryID(countryID);
            var cityDtos = new List<CityDto>();
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

        public CityDto GetCityByID(long ID)
        {
            var city = _placeRepository.GetCityByID(ID);
            var cityDto = new CityDto();
            cityDto.ID = city.ID;
            cityDto.Name = city.Name;
            cityDto.Country = city.Country.Name;
            cityDto.CountryID = city.CountryID;
            return cityDto;

        }

        public OperationResult Insert(string name, long countryID)
        {
            var operation = new OperationResult();
            var country = _placeRepository.GetCountryByID(countryID);
            var city = new City(name,countryID);
            city.Country = country;
            _placeRepository.InsertCity(city);
            operation.Succeded();
            return operation;
        }

        public OperationResult Remove(long ID)
        {
            var operation = new OperationResult();
            _placeRepository.RemoveCity(ID);
            operation.Succeded();
            return operation;
        }

        public OperationResult Update(CityDto city)
        {
            var operation = new OperationResult();
            var entity = _placeRepository.GetCityByID(city.ID);
            entity.Name = city.Name;
            entity.CountryID = city.CountryID;
            _placeRepository.UpdateCity(entity);
            operation.Succeded();
            return operation;
        }
    }
}
