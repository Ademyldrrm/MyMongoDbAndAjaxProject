using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutHeaderComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public _UILayoutHeaderComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _serviceCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
