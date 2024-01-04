using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMongoCollection<MessageCategory> _messagecategoryCollection;
        public ContactController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _messagecategoryCollection = database.GetCollection<MessageCategory>(_databaseSettings.MessageCategoryCollectionName);

        }
        public async Task<IActionResult> Index()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            await _contactCollection.InsertOneAsync(contact);
            return RedirectToAction("Index","_UILayout");
        }
    }
}
