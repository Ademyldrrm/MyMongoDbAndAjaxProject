using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.Controllers
{
    public class ContactInformationController : Controller
    {
        private readonly IMongoCollection<ContactInformation> _contactInformation;
        public ContactInformationController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactInformation = database.GetCollection<ContactInformation>(_databaseSettings.ContactInformationCollectionName);
        }

        public async  Task<IActionResult> Index()
        {
            var values = await _contactInformation.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateContactInformation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContactInformation(ContactInformation contactInformation)
        {
            await _contactInformation.InsertOneAsync(contactInformation);
            return RedirectToAction("Index");
        }
    }
}
