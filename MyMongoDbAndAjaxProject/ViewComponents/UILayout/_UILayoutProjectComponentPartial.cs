using Microsoft.AspNetCore.Mvc;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutProjectComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
