using Hoteland.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Domain.Models
{
    public class City : BaseModel
    {
        public string Name { get; set; }
        public long CountryID { get; set; }
        public virtual Country Country { get; set; }
        public ICollection<Hotel> Hotels { get; set; }

        public City(string name , long countryID)
        {
            Name = name;
            CountryID = countryID;
            Hotels = new List<Hotel>();
        }
        public City()
        {
            
        }
    }
}
