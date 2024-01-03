using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutProjectComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Project> _projectCollection;
        public _UILayoutProjectComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _projectCollection = database.GetCollection<Project>(_databaseSettings.ProjectCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var project = _projectCollection.Find(x => true).FirstOrDefault();
            ViewBag.ımage1 =project.Image1;
            ViewBag.ımage2 =project.Image2;
            ViewBag.ımage3 =project.Image3;
            ViewBag.ımage4 =project.Image4;
            ViewBag.ımage5 =project.Image5;
            ViewBag.ımage6 =project.Image6;         
            return View();
        }
    }
}
