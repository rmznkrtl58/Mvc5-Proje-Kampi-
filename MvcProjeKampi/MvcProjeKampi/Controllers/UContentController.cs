using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class UContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager vm = new WriterManager(new EfWriterDal());
        // GET: UContent
        public ActionResult MyContent(string p)
        {   
            //sayfama string türünde p parametresi yolluyorum ona göre
            //hareket edeceğim p'yi login ile giriş yapılan writermaile'
            //eşitliyorum
            p = (string)Session["writermail"];
            var writeridinfo = vm.GetListBySession(p).Select(x=>x.WriterId).FirstOrDefault();
            var ContentListbyWriter = cm.GetListContentByWriter(writeridinfo);
            return View(ContentListbyWriter);
        }
    }
}