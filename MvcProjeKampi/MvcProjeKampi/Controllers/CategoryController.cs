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
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        // GET: Category
        public ActionResult Index()
        {
            var CategoryValues = cm.GetList();
            return View(CategoryValues);
        }
        [HttpGet]
        public ActionResult CategoryInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryInsert(Category c)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(c);//c->parametremden gelen değerlerin
                                                      //doğruluğunu kontrol et
            if (results.IsValid)//doğrulama başarılıysa
            {
                cm.CategoryAdd(c);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult categoryremove(int id)
        {
            var categoryfind = cm.GetById(id);
            cm.CategoryDelete(categoryfind);
            return RedirectToAction("Index", "Category");
        }
        public ActionResult categoryedit(int id)
        {
            var categoryfind = cm.GetById(id);
            return View(categoryfind);
        }
        public ActionResult updatecategory(Category c)
        {
            cm.CategoryUpdate(c);
            return RedirectToAction("Index","Category");
        }
    }
}