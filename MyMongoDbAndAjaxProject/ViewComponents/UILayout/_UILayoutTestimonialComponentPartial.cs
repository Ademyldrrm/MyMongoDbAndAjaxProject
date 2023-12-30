using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutTestimonialComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        public _UILayoutTestimonialComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _testimonialCollection.Find(x => true).ToListAsync();
            return View(values);
        }

    }
}
