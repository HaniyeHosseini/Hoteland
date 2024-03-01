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
    public class PlaceRepository : IPlaceRepository
    {
        private readonly HotelandContext _context;

        public PlaceRepository(HotelandContext context)
        {
            _context = context;
        }

        public IList<City> GetCities()
        {
            return _context.Cities.Include(x=> x.Country).ToList();
        }

        public IList<City> GetCitiesByCountryID(long countryID)
        {
            return _context.Cities.Where(x => x.CountryID == countryID).Include(x=>x.Country).ToList();
        }

        public City GetCityByID(long ID)
        {
            return _context.Cities.Include(x=> x.Country).First(x=> x.ID==ID);
        }

        public IList<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryByID(long ID)
        {
            return _context.Countries.Find(ID);
        }

        public void InsertCity(City city)
        {
            _context.Add(city);
            _context.SaveChanges();

        }

        public void InsertCountry(Country country)
        {
            _context.Add(country);
            _context.SaveChanges();
        }

        public void RemoveCity(long ID)
        {
            var city = GetCityByID(ID);
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }

        public void RemoveCountry(long ID)
        {
            var country = GetCountryByID(ID);
            _context.Countries.Remove(country);
            _context.SaveChanges();

        }

        public void UpdateCity(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();

        }

        public void UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();

        }
    }
}
