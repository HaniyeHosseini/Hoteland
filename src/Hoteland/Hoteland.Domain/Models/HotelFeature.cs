using Hoteland.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Domain.Models
{
    public class HotelFeature : BaseModel
    {
        public long HotelID { get; set;}
        public long FeatureID { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
