using Hoteland.Domain.Base;
using Hoteland.Domain.Enums;
using NetTopologySuite.Geometries;
namespace Hoteland.Domain.Models
{
    public class Hotel : BaseModel
    {
        public string Name { get; set; }
        public long? CountryID { get; set; }
        public long? CityID { get; set; }
        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public string Address { get; set; }
        public string Tell { get; set; }
        public string Description { get; set; }
        public HotelStar HotelStar { get; set; }
        public Point Location { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public ICollection<HotelPicture> Pictures { get; set; }
        public ICollection<HotelFeature> Features { get; set; }

        public Hotel()
        {
            Pictures = new List<HotelPicture>();
            Features = new List<HotelFeature>();
        }
    }
}
