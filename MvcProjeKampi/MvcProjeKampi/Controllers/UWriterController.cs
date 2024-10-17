using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKampi.Controllers
{
    public class UWriterController : Controller
    {
        // GET: UWriter
        TitleManager tm = new TitleManager(new EfTitleDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager vm = new WriterManager(new EfWriterDal());
        ContentManager ContentManager = new ContentManager(new EfContentDal());
        WriterWalidator writervalidator = new WriterWalidator();
        
        [HttpGet]
        public ActionResult writerprofile()
        {
            string s = (string)Session["writermail"].ToString();
            int id = vm.GetListBySession(s).Select(x=>x.WriterId).FirstOrDefault();
            var writerinfos = vm.GetById(id);
            ViewBag.id = id;
            return View(writerinfos);
        }
        [HttpPost]
        public ActionResult writerprofile(Writer w)
        {
            ValidationResult results = writervalidator.Validate(w);
            if (results.IsValid)
            {
                w.WriterStatus = true;
                vm.WriterUpdate(w);
                return RedirectToAction("alltitles", "UWriter");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult mytitlelist(string p)
        {
            p = (string)Session["writermail"];
            var writeridinfo = vm.GetListBySession(p).Select(x=>x.WriterId).FirstOrDefault();
            ViewBag.value = writeridinfo;
            var Titlelist = tm.GetTitleListByWriter(writeridinfo);
            return View(Titlelist);
        }
        [HttpGet]
        public ActionResult newtitle(int id)
        {
            List<SelectListItem> CategoryDrop = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }
                                              ).ToList();
            ViewBag.cd = CategoryDrop;
            ViewBag.id = id;
            return View();

        }
        [HttpPost]
        public ActionResult newtitle(Title t)
        {
            t.TitleStatus = true;
            t.WriterId = 1;
            t.TitleDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            tm.InsertTitle(t);
            return RedirectToAction("mytitlelist","UWriter");
        }
        [HttpGet]
        public ActionResult edittitle(int id)
        {
            List<SelectListItem> CategoryDrop = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }
                                             ).ToList();
            ViewBag.cd = CategoryDrop;
            var titlevalues= tm.GetById(id);
            return View(titlevalues);
        }
        [HttpPost]
        public ActionResult edittitle(Title t)
        {
            t.TitleStatus = true;
            tm.UpdateTitle(t);
            return RedirectToAction("mytitlelist", "UWriter");
        }
        public ActionResult titledelete(int id)
        {
            var findtitle = tm.GetById(id);
            findtitle.TitleStatus = false;
            tm.UpdateTitle(findtitle);
            return RedirectToAction("mytitlelist", "UWriter");
        }
        public ActionResult alltitles(int page=1)//Sayfalama
        {
            var alltitles = tm.GetTitleList().ToPagedList(page,4);
            return View(alltitles);
        }
        [HttpGet]
        public ActionResult newcontent(int id)//başlığın id'sini taşıyıp
                                              //o başlığa ekleme yapmamızı sağlayacak
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult newcontent(Content c)
        {
            string mail = (string)Session["writermail"].ToString();
            var WriterId = vm.GetListBySession(mail).Select(x=>x.WriterId).FirstOrDefault();
            c.WriterId = WriterId;
            c.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.ContentStatus = true;
            ContentManager.ContentAdd(c);
            return RedirectToAction("MyContent","UContent");
        }
        
    }
}
/*<customErrors mode="On">
		  <error statusCode="404" redirect="/ErrorPage/Error404/"/>
	  </customErrors>*/