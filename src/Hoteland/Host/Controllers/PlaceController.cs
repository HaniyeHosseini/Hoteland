using Hoteland.Application.Contract.Place;
using Hoteland.Application.PlaceAgg;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("/")]
    public class PlaceController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        public PlaceController(ICountryService countryService, ICityService cityService)
        {
            _countryService = countryService;
            _cityService = cityService;
        }
        [Route("/GetCountries")]
        public IActionResult GetCountries()
        
        {
            var countries = _countryService.GetCountries();
            return View("CountryIndex",countries);
        }
        [HttpGet]
        [Route("/CreateCountry")]

        public IActionResult CreateCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCountry(CountryDto country)
        {
            _countryService.Insert(country.Name);
           return RedirectToAction("GetCountries");
        }

        [HttpGet]
        [Route("/UpdateCountry")]
        public IActionResult UpdateCountry(long ID)
        {
            var country = _countryService.GetCountryByID(ID);
            return View(country);
        }
        [HttpPost]
        [Route("/UpdateCountry")]
        public IActionResult UpdateCountry(CountryDto country)
        {
            _countryService.Update(country.Name , country.ID);
            return RedirectToAction("GetCountries");
        }
       
        [Route("/RemoveCountry")]
        public IActionResult RemoveCountry(long ID)
        {
            _countryService.Remove(ID);
            return RedirectToAction("GetCountries");
        }

        [Route("/GetCities")]
        public IActionResult GetCities()
        {
            var cities = _cityService.GetCities();
            return View("CityIndex", cities);
        }
        [HttpGet]
        [Route("/CreateCity")]

        public IActionResult CreateCity()
        {
            var countries = _countryService.GetCountries();
            var cityDto = new CityDto();
            cityDto.Countries = countries;
            return View(cityDto);
        }
        [HttpPost]
        [Route("/CreateCity")]
        public IActionResult CreateCity(CityDto city)
        {
            _cityService.Insert(city.Name,city.CountryID);
            return RedirectToAction("GetCities");
        }

        [HttpGet]
        [Route("/UpdateCity")]
        public IActionResult UpdateCity(long ID)
        {
            var city = _cityService.GetCityByID(ID);
            var countries = _countryService.GetCountries();
            city.Countries = countries;
            return View(city);
        }
        [HttpPost]
        [Route("/UpdateCity")]
        public IActionResult UpdateCity(CityDto city)
        {
            _cityService.Update(city);
            return RedirectToAction("GetCities");
        }
        [Route("/RemoveCity")]
        public IActionResult RemoveCity(long ID)
        {
            _cityService.Remove(ID);
            return RedirectToAction("GetCities");
        }
    }
}
