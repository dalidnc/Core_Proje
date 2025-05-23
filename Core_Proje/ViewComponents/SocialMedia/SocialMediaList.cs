﻿using BussinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.SocialMedia
{
    public class SocialMediaList:ViewComponent
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IViewComponentResult Invoke()
        {
            var values = socialMediaManager.TGetList();
            return View(values);
        }
    }
}
