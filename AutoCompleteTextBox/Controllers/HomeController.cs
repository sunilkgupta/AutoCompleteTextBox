using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoCompleteTextBox.Models;

namespace AutoCompleteTextBox.Controllers
{
    [Serializable]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult About(string ISBNorUPC)
        {
            if (RegExLogic.validateISBN(ISBNorUPC))
            {
                ViewBag.Message = SafeValue.ISBN;
            }
            else if (RegExLogic.validateUPC(ISBNorUPC))
            {
                ViewBag.Message = SafeValue.UPC;
            }
            else if (RegExLogic.validateLCCN(ISBNorUPC))
            {
                ViewBag.Message = SafeValue.LCCN;
            }
            else
            {
                ViewBag.Message = SafeValue.Nothing;
            }
            return View();
        }
        public ActionResult Autocomplete(string term)
        { 
            var db = new AutoDataContext();
            Session["value"] = term;
            var result = from c in db.InfoBooks.Select(p => p.BookName).Where(p => p.ToUpper().Contains(term.ToUpper())) select c.TrimStart().TrimEnd();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ISBNNumber(string name)
        {
            string term = Session["value"].ToString();
            var db = new AutoDataContext();
            var result1 = from c in db.InfoBooks where c.BookName.ToUpper().Contains(term.ToUpper()) select c.ISBN.Trim();
            return Json(result1, JsonRequestBehavior.AllowGet);
        }        

        public ActionResult Decription(string tags)
        {
            var db = new AutoDataContext();
            var result = (from c in db.BookImages select c.Description1.Contains(tags)).Take(1);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Books()
        {
            var db = new AutoDataContext();
            var result = db.InfoBooks.Select(p => p.BookName).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
