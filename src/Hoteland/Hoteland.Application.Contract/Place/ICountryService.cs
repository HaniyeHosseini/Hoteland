using Hoteland.Application.Contract.Feature;
using Hoteland.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.Contract.Place
{
    public interface ICountryService
    {
        OperationResult Insert(string name);
        OperationResult Update(string name, long ID);
        OperationResult Remove(long ID);
        IList<CountryDto> GetCountries();
        
        CountryDto GetCountryByID(long ID);
    }
}
