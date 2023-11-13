using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.Contract.Feature
{
    public class FeatureDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }
}
