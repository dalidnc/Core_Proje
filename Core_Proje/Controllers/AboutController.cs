using BussinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        [HttpGet]
        public IActionResult Index()
        {

            var values = aboutManager.TGetByID(4);

            return View(values);
        }


        [HttpPost]
        public IActionResult Index(About about)
        {
           aboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }

    }
}
