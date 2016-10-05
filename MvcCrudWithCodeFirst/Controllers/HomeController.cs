using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudWithCodeFirst.Controllers
{
    [AuthenticationRequired]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Authentication");
            }

            return View();
        }

        public string DummyPage()
        {
            return "This is dummy page";
        }
    }
}