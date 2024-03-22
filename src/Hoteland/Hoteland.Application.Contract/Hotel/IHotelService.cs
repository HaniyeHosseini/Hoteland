using Hoteland.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.Contract.Hotel
{
    public interface IHotelService
    {
        OperationResult InsertHotel(HotelDto hotel);
        OperationResult UpdateHotel(HotelDto hotel);
        OperationResult DeleteHotel(long ID);
        HotelDto GetHotel(long ID);
        IList<HotelDto> GetAllHotel();
    }
}
