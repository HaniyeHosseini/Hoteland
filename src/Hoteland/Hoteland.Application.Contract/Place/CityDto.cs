using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.Contract.Place
{
    public class CityDto
    {
        public long ID { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public IList<CountryDto> Countries { get; set; }
        public long CountryID { get; set; }

    }
}
