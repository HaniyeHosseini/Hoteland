using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Domain.Base
{
    public class BaseModel
    {
        public long ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public BaseModel()
        {
            CreationDate = DateTime.Now;
        }

    }
}
