using Hoteland.Application.Contract.Feature;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureServices _featureServices;

        public FeatureController(IFeatureServices featureServices)
        {
            _featureServices = featureServices;
        }

        public IActionResult Index()
        {
            var features = _featureServices.GetFeatures();
            return View(features);
        }
    }
}
