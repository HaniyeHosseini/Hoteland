using Hoteland.Application.Contract.FeatureAgg;
using Hoteland.Application.Contract.Hotel;
using Hoteland.Common;
using Hoteland.Domain.Enums;
using Hoteland.Domain.Models;
using Hoteland.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.HotelAgg
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IFeatureServices _featureServices;
        public HotelService(IHotelRepository hotelRepository, IFeatureServices featureServices)
        {
            _hotelRepository = hotelRepository;
            _featureServices = featureServices;
        }

        public OperationResult DeleteHotel(long ID)
        {
            var op = new OperationResult();
            try
            {
                _hotelRepository.Remove(ID);
                op.Succeded();
            }
            catch (Exception)
            {
                return op;
            }
            return op;
        }

        public IList<HotelDto> GetAllHotel()
        {
            var hotels = _hotelRepository.GetAll();
            var hotelDtos = new List<HotelDto>();
            foreach (var hotel in hotels)
            {
                var hotelDto = CreateHotelDto(hotel);
                hotelDtos.Add(hotelDto);
            }
            return hotelDtos;
        }

        public HotelDto GetHotel(long ID)
        {
            var hotel = _hotelRepository.GetByID(ID);
            var hotelDto = CreateHotelDto(hotel);
            return hotelDto;
        }

        public OperationResult InsertHotel(HotelDto hotel)
        {
            var op = new OperationResult();
            try
            {
                var entity = new Hotel();
                entity.Address = hotel.Address; 
                entity.Tell = hotel.Tell;
                entity.HotelStar = (HotelStar)hotel.HotelStar;
                entity.PictureTitle = hotel.PictureTitle;
                entity.PictureAlt = hotel.PictureAlt;
                entity.Picture = hotel.PicturePath;
                entity.City = new City { ID = hotel.CityID};
                entity.Country = new Country { ID = hotel.CountryID};
                entity.CountryID = hotel.CountryID;
                entity.CityID = hotel.CityID;
                entity.Description = hotel.Description;
                entity.Name = hotel.Name;
                entity.Features = _featureServices.CreateFeatures(hotel.Features);
                entity.Pictures = CreatePictures(hotel.Pictures);
                _hotelRepository.Insert(entity);
                op.Succeded();
                return op;
            }
            catch (Exception)
            {
                return op;
            }
        }

        public OperationResult UpdateHotel(HotelDto hotel)
        {
            var op = new OperationResult();
            try
            {
                var entity = _hotelRepository.GetByID(hotel.HotelID);
                entity.Address = hotel.Address;
                entity.Tell = hotel.Tell;
                entity.HotelStar = (HotelStar)hotel.HotelStar;
                entity.PictureTitle = hotel.PictureTitle;
                entity.PictureAlt = hotel.PictureAlt;
                entity.Picture = hotel.PicturePath;
                entity.City = new City { ID = hotel.CityID };
                entity.Country = new Country { ID = hotel.CountryID };
                entity.CountryID = hotel.CountryID;
                entity.CityID = hotel.CityID;
                entity.Description = hotel.Description;
                entity.Name = hotel.Name;
                _hotelRepository.Update(entity);
                op.Succeded();
                return op;
            }
            catch (Exception)
            {
                return op;
            }
        }
        private IList<PictureDto> GetPictures(long hotelID)
        {
            var pictures = _hotelRepository.GetPicturesByHoteID(hotelID);
            var pictureResults = new List<PictureDto>();
            foreach (var picture in pictures)
            {
                var pictureDto = new PictureDto();
                pictureDto.ID = picture.ID;
                pictureDto.PictureTitle = picture.PictureTitle;
                pictureDto.PictureAlt = picture.PictureAlt;
                pictureDto.PicturePath = picture.PicturePath;
                pictureDto.HotelID = picture.HotelID;
                pictureResults.Add(pictureDto);
            }
            return pictureResults;
        }
        private HotelDto CreateHotelDto(Hotel hotel)
        {
            var hotelDto = new HotelDto();
            var features = _featureServices.GetFeaturesByHotelID(hotel.ID);
            var pictures = GetPictures(hotel.ID);
            hotelDto.HotelID = hotel.ID;
            hotelDto.Name = hotel.Name;
            hotelDto.Address = hotel.Address;
            hotelDto.City = hotel.City.Name;
            hotelDto.CityID = (long)hotel.CityID;
            hotelDto.Country = hotel.Country.Name;
            hotelDto.CountryID = (long)hotel.CountryID;
            hotelDto.Description = hotel.Description;
            hotelDto.Features = features;
            hotelDto.Pictures = pictures;
            hotelDto.PicturePath = hotel.Picture;
            hotelDto.PictureAlt = hotel.PictureAlt;
            hotelDto.PictureTitle = hotel.PictureTitle;
            hotelDto.HotelStar = (int)hotel.HotelStar;
            hotelDto.Tell = hotel.Tell;
            hotelDto.Location = hotel.Location;
            return hotelDto;
        }
        private List<HotelPicture> CreatePictures(IList<PictureDto> pictures)
        {
            var entities = new List<HotelPicture>();
            foreach (PictureDto picture in pictures)
            {
                entities.Add(new HotelPicture
                {
                    Hotel = new Hotel { ID = picture.HotelID },
                    PictureAlt = picture.PictureAlt,
                    PictureTitle = picture.PictureTitle,
                    PicturePath = picture.PicturePath
                });
            }
            return entities;
        }
    }
}
