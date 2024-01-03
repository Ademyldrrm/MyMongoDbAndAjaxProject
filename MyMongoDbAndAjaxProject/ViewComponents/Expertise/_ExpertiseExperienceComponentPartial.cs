using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.Expertise
{
    public class _ExpertiseExperienceComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Experience> _experienceCollection;
        public _ExpertiseExperienceComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _experienceCollection = database.GetCollection<Experience>(_databaseSettings.ExperienceCollectionName);

        }
        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _experienceCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
