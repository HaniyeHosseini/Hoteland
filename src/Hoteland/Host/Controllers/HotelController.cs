using Hoteland.Application.Contract.FeatureAgg;
using Hoteland.Application.Contract.Hotel;
using Hoteland.Application.Contract.Place;
using Hoteland.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HotelController(IHotelService hotelService,
            ICityService cityService, ICountryService countryService, IWebHostEnvironment hostingEnvironment)
        {
            _hotelService = hotelService;
            _cityService = cityService;
            _countryService = countryService;
            _hostingEnvironment = hostingEnvironment;
        }
        [Route("Hotel")]
        [Route("")]
        public IActionResult Index()
        {
            var hotels = _hotelService.GetAllHotels();
            return View(hotels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var countries = _countryService.GetCountries();
            var cities = _cityService.GetCities();
            var hotelDto = new HotelDto();
            hotelDto.Countries = countries;
            hotelDto.Cities = cities;
            hotelDto.Features = new List<FeatureDto>();
            hotelDto.Pictures = new List<PictureDto>();
            return View(hotelDto);
        }
        [HttpPost]
        public IActionResult Create(HotelDto hotelDto)
        {
            if (hotelDto.Picture != null)
            {
                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "Hotels");
                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);
                var fileName = $"{Guid.NewGuid()}-{hotelDto.Picture.FileName}";
                var filePath = Path.Combine(uploadFolder, fileName);
                hotelDto.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                hotelDto.Pictures = new List<PictureDto>();
                hotelDto.Features=new List<FeatureDto>();
                _hotelService.InsertHotel(hotelDto, $"Hotels\\{fileName}");
            }
            return RedirectToAction("Index");
        }
        public IList<CityDto> FilterCitiesByCountry(object countryId)
        {
            var cities = _cityService.GetCitiesByCountryID((long)countryId);
            return cities;
        }

    }
}
