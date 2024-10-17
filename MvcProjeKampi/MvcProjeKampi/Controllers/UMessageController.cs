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
    public class UMessageController : Controller
    {
        MessageManager mn = new MessageManager(new EfMessageDal());
        // GET: UMessage
        public ActionResult Inbox()
        {
            string m = (string)Session["writermail"].ToString();
            var messages = mn.GetListInbox(m);
            return View(messages);
        }
        public ActionResult Sendbox()
        {
            string m = (string)Session["writermail"].ToString();
            var messages = mn.GetListSendBox(m);
            return View(messages);
        }
        public PartialViewResult messagelistmenu()
        {
            return PartialView();
        }
        public ActionResult getinboxmessagedetails(int id)
        {
            var messagedetails = mn.GetById(id);
            return View(messagedetails);
        }
        public ActionResult getsendboxmessagedetails(int id)
        {
            var messagedetails = mn.GetById(id);
            return View(messagedetails);
        }
        [HttpGet]
        public ActionResult newmessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newmessage(Message m)
        {
            string s = (string)Session["writermail"].ToString();
            m.SenderMail = s;
            m.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mn.MessageAdd(m);
            return RedirectToAction("Sendbox", "UMessage");
        }
    }
}