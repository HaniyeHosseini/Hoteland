using Hoteland.Application.Contract.Feature;
using Hoteland.Common;
using Hoteland.Domain.Models;
using Hoteland.Infrastructure.Repository.Interfaces;

namespace Hoteland.Application.FeatureAgg
{
    public class FeatureServices : IFeatureServices
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureServices(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

		public FeatureDto GetFeatureByID(long ID)
		{
            var feature = _featureRepository.GetByID(ID); 
            return new FeatureDto()
            {
                Name = feature.Name,
                ID = feature.ID,
                PicturePath = feature.Picture
            };
		}

		public IList<FeatureDto> GetFeatures()
        {
            var features = _featureRepository.GetAll();
            var featureDtos = new List<FeatureDto>(features.Count);
            foreach (var item in features)
            {
                var featureDto = new FeatureDto()
                {
                    ID = item.ID,
                    CreationDate = item.CreationDate,
                    LastUpdateDate = item.LastUpdateDate,
                    Name = item.Name,
                    PicturePath = item.Picture , 
                };
                featureDtos.Add(featureDto);
            }
            return featureDtos;
        }

        public OperationResult Insert(string name, string picture)
        {
            var op = new OperationResult();
            try
            {
                var feature = new Feature(name, picture);
                _featureRepository.Insert(feature);
                op.Succeded();
                return op;
            }
            catch (Exception)
            {

                return op;
            }

        }

        public OperationResult Remove(long ID)
        {
            var op = new OperationResult();
            try
            {
                _featureRepository.Remove(ID);
                op.Succeded();
                return op;
            }
            catch (Exception)
            {
                return op;
            }
        }

        public OperationResult Update(string name, string picture, long ID)
        {
            var op = new OperationResult();
            try
            {
                var feature = _featureRepository.GetByID(ID);
                feature.Name = name;
                feature.Picture = picture;
                feature.LastUpdateDate = DateTime.Now;
                _featureRepository.Update(feature);
                op.Succeded();
                return op;
            }
            catch (Exception)
            {
                return op;
            }
        }
    }
}
