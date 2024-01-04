using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.ViewComponents.About
{
        public class _AboutStatisticComponentPartial : ViewComponent
        {
        private readonly IMongoCollection<Service> _serviceCollection;
        private readonly IMongoCollection<Testimonial> _testimonialCollection;

        public _AboutStatisticComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            _serviceCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
        }
        public IViewComponentResult Invoke()
        {
            var serviceCount = _serviceCollection.CountDocuments(FilterDefinition<Service>.Empty);
            var testimonialCount = _testimonialCollection.CountDocuments(FilterDefinition<Testimonial>.Empty);

            ViewBag.serviceCount = serviceCount;
            ViewBag.testimonialCount = testimonialCount;
            return View();
        }
        }

    }
