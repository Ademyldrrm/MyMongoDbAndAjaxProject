using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IMongoCollection<Statistic> _statisticCollection;
        public StatisticController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _statisticCollection = database.GetCollection<Statistic>(_databaseSettings.StatisticCollectionName);

        }
        public async Task<IActionResult> Index()
        {
            var values = await _statisticCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateStatistic()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStatistic(Statistic statistic)
        {
            await _statisticCollection.InsertOneAsync(statistic);
            return RedirectToAction("Index");
        }

    }
}