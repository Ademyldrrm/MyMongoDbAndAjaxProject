using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.Controllers
{
    public class EdicationController : Controller
    {
        private readonly IMongoCollection<Edication> _edicationCollection;
        public EdicationController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _edicationCollection = database.GetCollection<Edication>(_databaseSettings.EdicationCollectionName);

        }
        public async  Task<IActionResult> Index()
        {
            var values = await _edicationCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateEdication()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEdication(Edication edication)
        {
            await _edicationCollection.InsertOneAsync(edication);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteExperience(string id)
        {
            await _edicationCollection.DeleteOneAsync(x => x.EdicationID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEdication(string id)
        {
            var values = await _edicationCollection.Find(x => x.EdicationID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEdication(Edication edication)
        {
            await _edicationCollection.FindOneAndReplaceAsync(x => x.EdicationID == edication.EdicationID, edication);
            return RedirectToAction("Index");
        }
    }
}
