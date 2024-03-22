using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace Hoteland.Application.Contract.FeatureAgg
{
    public class FeatureDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
        public string PicturePath { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public long? HotelID { get; set; }
    }
}
