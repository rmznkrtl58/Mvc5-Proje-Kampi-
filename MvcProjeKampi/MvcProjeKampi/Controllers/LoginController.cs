using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{   [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        // GET: Login
        Context ent = new Context();
        [HttpGet]
        public ActionResult Index()
        {
            return View();    
        }
        [HttpPost]
        public ActionResult Index(Admin a)
        {
            var admininfo = ent.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.PassWord == a.PassWord);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                                                //False->Kalıcı Çerez Oluşsunmu tabiki hayır
                Session["username"] = admininfo.UserName.ToString();
                return RedirectToAction("Index", "Title");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult ULogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ULogin(Writer w)
        {
            var writerinfo = wlm.GetWriter(w.WriterMail, w.WriterPassword);
            if (writerinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerinfo.WriterMail, false);
                Session["writermail"] = writerinfo.WriterMail.ToString();
                return RedirectToAction("MyContent", "UContent");
            }
            else
            {
                return View();
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Titles","Default");
        }

    }
}