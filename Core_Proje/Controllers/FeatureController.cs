using BussinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class FeatureController : Controller
    {
      
        FeatureManager featureManager = new FeatureManager(new EfAboutManager());

        [HttpGet]
        public IActionResult Index()
        {
           
            var values = featureManager.TGetByID(1);

            return View(values);
        }
    
      
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            featureManager.TUpdate(feature);
            return RedirectToAction("Index","Default");
        }
    
    }
}
