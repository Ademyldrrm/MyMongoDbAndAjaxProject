using Microsoft.AspNetCore.Mvc;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutAboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
