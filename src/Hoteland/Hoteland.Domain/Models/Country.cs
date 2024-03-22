using Hoteland.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Domain.Models
{
    public class Country : BaseModel
    {
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Hotel> Hotels { get; set; }

        public Country(string name)
        {
            Name = name;
            Cities = new List<City>();
            Hotels = new List<Hotel>();
        }
        public Country()
        {
        }
    }
}
