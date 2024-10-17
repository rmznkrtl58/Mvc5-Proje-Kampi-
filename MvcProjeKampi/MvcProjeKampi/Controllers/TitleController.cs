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
    public class TitleController : Controller
    {
        // GET: Title
        TitleManager tm = new TitleManager(new EfTitleDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var TitleList = tm.GetTitleList();
            return View(TitleList);
        }
        public ActionResult titlereport()
        {
            var TitleList = tm.GetTitleList();
            return View(TitleList);
        }
        [HttpGet]
        public ActionResult addtitle()
        {
            List<SelectListItem> CategoryDropDown = (from x in cm.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CategoryName,
                                                         Value = x.CategoryId.ToString()
                                                     }
                                                  ).ToList();
            List<SelectListItem> WriterDropDown = (from x in wm.WriterGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.WriterName + " " + x.WriterSurName+"-"+x.WriterTitle,
                                                       Value = x.WriterId.ToString()
                                                   }
                                                ).ToList();
            ViewBag.cd = CategoryDropDown;
            ViewBag.wd = WriterDropDown;
            return View();
        }
        [HttpPost]
        public ActionResult addtitle(Title t)
        {  
            t.TitleDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            tm.InsertTitle(t);
            return RedirectToAction("Index", "Title");
        }
        [HttpGet]
        public ActionResult edittitle(int id)
        {
            List<SelectListItem> categorydrop = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.cd = categorydrop;
            var titlevalue = tm.GetById(id);
            return View("edittitle",titlevalue);
        }
        [HttpPost]
        public ActionResult edittitle(Title t)
        {   //Güncelleme İşlemi
            //var titlewriter = tm.titlewriterlist(t.TitleId).Select(x=>x.WriterId).FirstOrDefault();
            //ViewBag.tw = titlewriter;
            //var titledate = tm.titlewriterlist(t.TitleId).Select(x => x.TitleDate).FirstOrDefault();
            //t.TitleDate = Convert.ToDateTime(titledate);
            t.TitleStatus = true;
            tm.UpdateTitle(t);
            return RedirectToAction("Index","Title");
        }
        public ActionResult deletetitle(int id)
        {
            var titlefind = tm.GetById(id);
            titlefind.TitleStatus = false;
            tm.DeleteTitle(titlefind);
            return RedirectToAction("Index", "Title");
        }
    }
}