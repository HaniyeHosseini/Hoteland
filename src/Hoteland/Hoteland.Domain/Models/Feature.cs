using Hoteland.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Domain.Models
{
    public class Feature : BaseModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }

    }
}
