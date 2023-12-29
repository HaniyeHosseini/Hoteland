using Hoteland.Application.Contract.Feature;
using Hoteland.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
	public class FeatureController : Controller
	{
		private readonly IFeatureServices _featureServices;
		private readonly IWebHostEnvironment _hostingEnvironment;
		public FeatureController(IFeatureServices featureServices, IWebHostEnvironment hostingEnvironment)
		{
			_featureServices = featureServices;
			_hostingEnvironment = hostingEnvironment;
		}

		public IActionResult Index()
		{

			var features = _featureServices.GetFeatures();
			return View(features);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(FeatureDto feature)
		{
			
			if (feature.Picture != null)
			{
				var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "Features");
				if (!Directory.Exists(uploadFolder))
					Directory.CreateDirectory(uploadFolder);
				var fileName = $"{Guid.NewGuid()}-{feature.Picture.FileName}";
				var filePath = Path.Combine(uploadFolder, fileName);
				feature.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
				_featureServices.Insert(feature.Name, $"Features\\{fileName}");
			}

			return RedirectToAction("Index");
				
		}
		[HttpGet]
		public IActionResult Update(long ID)
		{
			var feature = _featureServices.GetFeatureByID(ID);
			return View(feature);
		}
		[HttpPost]

		public IActionResult Update(FeatureDto feature)
		{
			if (feature.Picture != null)
			{
				var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "Features");
				if (!Directory.Exists(uploadFolder))
					Directory.CreateDirectory(uploadFolder);
				var fileName = $"{Guid.NewGuid()}-{feature.Picture.FileName}";
				var filePath = Path.Combine(uploadFolder, fileName);
				feature.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
				_featureServices.Update(feature.Name, $"Features\\{fileName}",feature.ID);
			}

			return RedirectToAction("Index");
		}
		public IActionResult Remove(long ID)
		{
			_featureServices.Remove(ID);
            return RedirectToAction("Index");

        }

    }
}
