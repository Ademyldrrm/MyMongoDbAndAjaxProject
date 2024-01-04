using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.Controllers
{
    public class MessageCategoryController : Controller
    {
        private readonly IMongoCollection<MessageCategory> _messageCategoryCollection;
        public MessageCategoryController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _messageCategoryCollection = database.GetCollection<MessageCategory>(_databaseSettings.MessageCategoryCollectionName);

        }
        public async Task<IActionResult> Index()
        {
            var values = await _messageCategoryCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateMessageCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageCategory(MessageCategory messageCategory)
        {
            await _messageCategoryCollection.InsertOneAsync(messageCategory);
            return RedirectToAction("Index");
        }
    }
}
