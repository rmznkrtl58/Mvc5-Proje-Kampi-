using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var contactlist = cm.GetContactList();
            return View(contactlist);
        }
        public ActionResult getcontactmessage(int id)
        {
            var ContactValues= cm.GetById(id);
            return View(ContactValues);
        }
        public PartialViewResult MessageBox()
        {
            return PartialView();
        }
    }
}