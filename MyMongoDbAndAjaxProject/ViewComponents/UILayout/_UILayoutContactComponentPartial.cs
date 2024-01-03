using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutContactComponentPartial:ViewComponent
    {

        private readonly IMongoCollection<ContactInformation> _contactInformation;
        public _UILayoutContactComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactInformation = database.GetCollection<ContactInformation>(_databaseSettings.ContactInformationCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var contact = _contactInformation.Find(x => true).FirstOrDefault();
            ViewBag.Adress=contact.Adress;
            ViewBag.Telefon=contact.Phone;
            ViewBag.Mail=contact.Mail;
            return View();
        }
    }
}
