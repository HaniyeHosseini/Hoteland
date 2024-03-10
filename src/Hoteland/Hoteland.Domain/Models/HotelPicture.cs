using Hoteland.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Domain.Models
{
    public class HotelPicture : BaseModel
    {
        public string PicturePath { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public long HotelID { get; set; }
        public  Hotel Hotel { get; set; }
    }
}
