using MvcCrudWithCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudWithCodeFirst.Controllers
{
    public class AuthenticationController : Controller
    {
        XCourseContext _db;

        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Credential credential)
        {
            _db = new XCourseContext();

            Models.User user = _db.Users.FirstOrDefault(u => u.Username == credential.Username && u.Password == credential.Password);

            if (user == null)
            {
                TempData["ResultMessage"] = "Kullanıcı adınız veya şifreniz hatalı! Tekrar deneyin.";
                return View();
            }
            else
            {
                Session["User"] = user;
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}