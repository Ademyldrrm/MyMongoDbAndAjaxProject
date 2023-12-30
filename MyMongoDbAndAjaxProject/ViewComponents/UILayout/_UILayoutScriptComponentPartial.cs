using Microsoft.AspNetCore.Mvc;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
