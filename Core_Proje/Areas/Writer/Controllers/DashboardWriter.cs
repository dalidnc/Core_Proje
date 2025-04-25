 using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardWriter : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardWriter(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;


            //string api = "a97a22fa1acd5de6933057942d8f2dde";
            //string connection = "http://api.openweathermap.org/data/2.5/weather?q=Bolu,TR&mode=xml&lang=tr&units=metric&appid=" + api;
            //XDocument document = XDocument.Load(connection);
            //ViewBag.v = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            ////İstatislikler
            Context context = new Context();

            ViewBag.v1 = context.WriterMessages.Where(x=>x.Receiver == values.Email).Count(); 
            ViewBag.v1 = context.Announcements.Count();
            ViewBag.v2 = context.Users.Count();//ASP NET User sayısına ulaşıcaz
            ViewBag.v3 = context.Users.Count();
            ViewBag.v4 = context.Skills.Count(); 
            return View();
        }
    }
}
