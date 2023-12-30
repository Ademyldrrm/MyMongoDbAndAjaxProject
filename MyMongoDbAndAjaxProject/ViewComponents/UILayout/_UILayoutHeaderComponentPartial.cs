using Microsoft.AspNetCore.Mvc;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
