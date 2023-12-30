using Microsoft.AspNetCore.Mvc;

namespace MyMongoDbAndAjaxProject.Controllers
{
    public class _UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
