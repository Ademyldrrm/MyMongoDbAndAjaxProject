using Microsoft.AspNetCore.Mvc;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutMapComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
