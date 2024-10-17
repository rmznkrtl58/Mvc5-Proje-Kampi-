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
    public class AuthorizationController : Controller
    {
        AdminManager adminmanager = new AdminManager(new EfAdminDal());
        // GET: Authorization
        [HttpGet]
        public ActionResult Index()
        {
            var adminvalues = adminmanager.GetListAdmin();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult editadmin(int id)
        {
            var admininfo = adminmanager.GetById(id);
            return View(admininfo);
        }
        [HttpPost]
        public ActionResult editadmin(Admin a)
        {
            adminmanager.AdminUpdate(a);
            return RedirectToAction("Index","Authorization");
        }
        [HttpGet]
        public ActionResult AdminInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminInsert(Admin a)
        {
            adminmanager.AdminAdd(a);
            return RedirectToAction("Index","Authorization");
        }
    }
}