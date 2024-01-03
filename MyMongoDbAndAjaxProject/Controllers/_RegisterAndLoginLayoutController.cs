using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMongoDbAndAjaxProject.DAL.Entities;
using MyMongoDbAndAjaxProject.DAL.Settings;
using MyMongoDbAndAjaxProject.Models;

namespace MyMongoDbAndAjaxProject.Controllers
{
    public class _RegisterAndLoginLayoutController : Controller
    {
        private readonly IMongoCollection<Register> _registerCollection;
        public _RegisterAndLoginLayoutController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _registerCollection = database.GetCollection<Register>(_databaseSettings.RegisterCollectionName);

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> RegiserList()
        {
            var values = await _registerCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRegister(Register register)
        {
            await _registerCollection.InsertOneAsync(register);
            return RedirectToAction("RegiserList");
        }

        [HttpGet]
        public IActionResult CreateRegister2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRegister2(Register register)
        {
            await _registerCollection.InsertOneAsync(register);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
            var user = await _registerCollection
                    .Find(u => u.NameSurname == loginUserViewModel.NameSurname && u.Password == loginUserViewModel.Password)
                    .FirstOrDefaultAsync();
            if (user != null)
            {
               
                return RedirectToAction("Index", "Contact");
            }
            else
            {
               
                return RedirectToAction("Index");
            }
        
        }

    }
}
