using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;
using Newtonsoft.Json;

namespace MyMongoDbAndAjaxProject.Controllers
{
    public class SkillController : Controller
    {
        private readonly IMongoCollection<Skill> _skillCollection;
        public SkillController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _skillCollection = database.GetCollection<Skill>(_databaseSettings.SkillCollectionName);

        }
        public IActionResult Index()
        {
           
            return View();
        }
        public async Task< IActionResult> SkillList()
        {
            var values = await _skillCollection.Find(x => true).ToListAsync();
            var jsonSkills = JsonConvert.SerializeObject(values);
            return Json(jsonSkills);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            await _skillCollection.InsertOneAsync(skill);
            var values=JsonConvert.SerializeObject(skill);
            return Json(values);
        }

        public async Task<IActionResult> Getskill(string skillid)
        {
            var values =await _skillCollection.Find(x => x.SkillID == skillid).FirstOrDefaultAsync();
            var jsonValues=JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
        public async Task<IActionResult> DeleteSkill(string id)
        {
            await _skillCollection.DeleteOneAsync(x => x.SkillID == id);
            return NoContent();
        }
        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            var values = await _skillCollection.FindOneAndReplaceAsync(x => x.SkillID == skill.SkillID, skill);
            return NoContent();
        }
    }
}
