using Microsoft.AspNetCore.Mvc;

namespace MyMongoDbAndAjaxProject.ViewComponents.UILayout
{
    public class _UILayoutTeamComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
