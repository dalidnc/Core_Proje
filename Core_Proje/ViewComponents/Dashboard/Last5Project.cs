using BussinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class Last5Project:ViewComponent
    {
            public IViewComponentResult Invoke()
            {
                
                return View();
            }

        
    }
}
