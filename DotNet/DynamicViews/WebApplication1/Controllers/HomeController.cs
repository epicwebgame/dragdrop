using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Articles()
        {
            IEnumerable<Article> articles = null;

            using (var context = new PracticeEntities())
            {
                articles = context.Articles.ToList();
            }

            return View(articles);
        }

        [Route("Articles/{id}")]
        public ActionResult DisplayArticle(string id)
        {
            var viewPath = string.Format($"~/Views/DynamicViews/{id}.cshtml");

            return View((object)viewPath);
        }
    }
}