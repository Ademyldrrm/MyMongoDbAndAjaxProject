using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutExpertiseComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Skill> _skillCollection;
        public _UILayoutExpertiseComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _skillCollection = database.GetCollection<Skill>(_databaseSettings.SkillCollectionName);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _skillCollection.Find(x=> true).ToListAsync();
            return View(values);
        }
    }
}
