using BussinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Feature
{
    public class FeatureList: ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EfAboutManager());
        public IViewComponentResult Invoke()
        {
            var values= featureManager.TGetList();
            return View(values);
        }
    }
}
