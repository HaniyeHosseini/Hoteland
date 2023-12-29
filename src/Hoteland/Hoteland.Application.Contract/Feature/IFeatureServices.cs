using Hoteland.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteland.Application.Contract.Feature
{
    public interface IFeatureServices
    {
        OperationResult Insert(string name, string picture);
        OperationResult Update(string name, string picture , long ID);
        OperationResult Remove(long ID);
        IList<FeatureDto> GetFeatures();
        FeatureDto GetFeatureByID(long ID);
    }
}
