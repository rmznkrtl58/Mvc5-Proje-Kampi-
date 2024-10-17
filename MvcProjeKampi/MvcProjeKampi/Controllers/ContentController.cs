using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult contentbyheading(int id)
        {
            var ContentListbyheading = cm.GetListContentByTitleId(id);
            return View(ContentListbyheading);
        }
        public ActionResult getallcontent(string p=" ")
        {
            var contentlist = cm.GetListContent(p);
            return View(contentlist);
        }
    }
}