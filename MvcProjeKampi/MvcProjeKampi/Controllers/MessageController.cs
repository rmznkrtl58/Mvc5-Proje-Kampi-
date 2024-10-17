using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager MessageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: Message
        
        public ActionResult Inbox(string m)//Gelen Mesajlar
        {
            m = (string)Session["username"].ToString();
            var messagelist = MessageManager.AdminGetListInbox(m);
            return View(messagelist);
        }
        public ActionResult sendbox(string m)
        {
            m = (string)Session["username"].ToString();
            var messagelist = MessageManager.AdminGetListSendBox(m);
            return View(messagelist);
        }
        [HttpGet]
        public ActionResult newmessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newmessage(Message m)
        {
            m.SenderMail = "admin@gmail.com";
            m.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            MessageManager.MessageAdd(m);
            return RedirectToAction("sendbox","Message");
        }
        public ActionResult getinboxmessagedetails(int id)
        {
            var findmessage = MessageManager.GetById(id);
            return View(findmessage);
        }
    }
}