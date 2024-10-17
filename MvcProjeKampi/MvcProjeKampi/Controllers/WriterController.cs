using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterWalidator writervalidator = new WriterWalidator();

        public object ValidationResults { get; private set; }

        // GET: Writer
        public ActionResult Index()
        {
            var writerlist = wm.WriterGetList();
            return View(writerlist);
        }
        [HttpGet]
        public ActionResult addwriter()
        {
            return View();
        }
       [HttpPost]
        public ActionResult addwriter(Writer p)
        {
            
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterInsert(p);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult writeredit(int id)
        {
            return View(wm.GetById(id));
        }
        [HttpPost]
        public ActionResult writerupdate(Writer p)
        {
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                p.WriterStatus = true;
                wm.WriterUpdate(p);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                foreach(var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
    }
}