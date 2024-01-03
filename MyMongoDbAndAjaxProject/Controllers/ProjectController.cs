using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;

namespace MyMongoDbAndAjaxProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IMongoCollection<Project> _projectCollection;
        public ProjectController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _projectCollection = database.GetCollection<Project>(_databaseSettings.ProjectCollectionName);

        }
        public async Task<IActionResult> Index()
        {
            var values = await _projectCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            await _projectCollection.InsertOneAsync(project);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteProject(string id)
        {
            await _projectCollection.DeleteOneAsync(x => x.ProjectID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProject(string id)
        {
            var values = await _projectCollection.Find(x => x.ProjectID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            await _projectCollection.FindOneAndReplaceAsync(x => x.ProjectID == project.ProjectID, project);
            return RedirectToAction("Index");
        }
    }
}
