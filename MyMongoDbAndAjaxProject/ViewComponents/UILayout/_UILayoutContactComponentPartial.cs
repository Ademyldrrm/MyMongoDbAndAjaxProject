using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutContactComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<MessageCategory> _messagecategoryCollection;
        private readonly IMongoCollection<ContactInformation> _contactInformation;
        public _UILayoutContactComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactInformation = database.GetCollection<ContactInformation>(_databaseSettings.ContactInformationCollectionName);
            
            _messagecategoryCollection = database.GetCollection<MessageCategory>(_databaseSettings.MessageCategoryCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var messageCategories = _messagecategoryCollection.Find(mc => true).ToList();

            List<SelectListItem> messageCategoryList = (from mc in messageCategories
                                                        select new SelectListItem
                                                        {
                                                            Text = mc.MessageCategoryName,
                                                            Value = mc.MessageCategoryID.ToString()
                                                        }).ToList();

            ViewBag.MessageCategories = messageCategoryList;

            var contact = _contactInformation.Find(x => true).FirstOrDefault();
            ViewBag.Adress=contact.Adress;
            ViewBag.Telefon=contact.Phone;
            ViewBag.Mail=contact.Mail;
            return View();
        }
    }
}
