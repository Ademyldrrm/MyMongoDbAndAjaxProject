using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.Expertise
{
    public class _ExpertiseEdicationComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Edication> _edicationCollection;
        public _ExpertiseEdicationComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _edicationCollection = database.GetCollection<Edication>(_databaseSettings.EdicationCollectionName);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _edicationCollection.Find(x => true).ToListAsync();   
            return View(values);
        }
    }
}
