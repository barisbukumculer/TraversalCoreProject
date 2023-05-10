using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents
{
    public class _Feature:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
