using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {  
        TitleManager tm = new TitleManager(new EfTitleDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        
        // GET: Default
        public ActionResult Titles()
        {
            var titlelist = tm.GetTitleList();
            return View(titlelist);
        }
        public PartialViewResult contentlist(int id=0)
        {
            var contentlist = cm.GetListContentByTitleId(id);
            return PartialView(contentlist);
        }
        [AllowAnonymous]
        public ActionResult homepage()
        {
            return View();
        }
    }
}