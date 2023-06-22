using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        Context c= new Context();   
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.v =c.Comments.Where(x=>x.DestinationID==id).Count();
            var values=commentManager.TGetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
