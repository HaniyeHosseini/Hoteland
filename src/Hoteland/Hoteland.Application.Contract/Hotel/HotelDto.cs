using Hoteland.Application.Contract.FeatureAgg;
using Hoteland.Application.Contract.Place;
using Microsoft.AspNetCore.Http;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.Contract.Hotel
{
    public class HotelDto
    {
        public long HotelID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tell { get; set; }
        public long CountryID { get; set; }
        public long CityID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public  int HotelStar { get; set; }
        public IFormFile Picture { get; set; }
        public string PicturePath { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public IList<FeatureDto> Features { get; set; }
        public IList<PictureDto> Pictures { get; set; }
        public Point Location { get; set; }
        public IList<CountryDto> Countries { get; set; }
        public IList<CityDto> Cities { get; set; }


    }
}
