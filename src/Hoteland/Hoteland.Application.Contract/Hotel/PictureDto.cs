using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.Contract.Hotel
{
    public class PictureDto
    {
        public long ID { get; set; }
        public IFormFile Picture { get; set; }
        public string PicturePath { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public long HotelID { get; set; }
    }
}
