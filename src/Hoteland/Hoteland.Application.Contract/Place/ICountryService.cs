using Hoteland.Common;

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
