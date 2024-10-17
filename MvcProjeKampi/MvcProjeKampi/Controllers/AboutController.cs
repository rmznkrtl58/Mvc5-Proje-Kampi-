using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
   
    public class AboutController : Controller
    {
        AboutManager about = new AboutManager(new EfAboutDal());
        // GET: About
        [HttpGet]
        public ActionResult Index()
        {
            var aboutinfo= about.GetById();
            return View(aboutinfo);
        }
        [HttpPost]
        public ActionResult Index(About a)
        {
            about.UpdateAbout(a);
            return RedirectToAction("Index","About");
        }
    }
}