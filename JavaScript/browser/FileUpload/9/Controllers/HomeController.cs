using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;

namespace _9.Controllers
{
    public class HomeController : Controller
    {
        // Hidden file input control, preview and upload
        // Drag and drop, preview and upload
        // Ajax upload single image file
        // Ajax upload many files

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult InputTypeFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InputTypeFile(HttpPostedFileBase[] files)
        {
            Debugger.Break();

            return Content("Files uploaded");
        }
    }
}