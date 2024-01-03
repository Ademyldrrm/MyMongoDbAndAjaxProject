using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.RegisterAndLogin
{
    public class _RegisterAndLoginLoginComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
    }