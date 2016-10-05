using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudWithCodeFirst.Controllers
{
    public class HelperController : Controller
    {
        // www.bişey.com/Helper/GetMessages bu şekilde bu Action çalıştırılamaz
        [ChildActionOnly]
        public ActionResult GetMessages()
        {
            Models.User currentUser = (Models.User)Session["User"];

            Models.XCourseContext db = new Models.XCourseContext();

            List<Models.Message> messageList = db.Messages
                .Include("Sender") // Eagerly Loading
                .Include("Receiver") // Eagerly Loading
                .Where(m => m.ReceiverId == currentUser.Id)
                .ToList();

            return PartialView("_Messages", messageList);
        }

        [ChildActionOnly]
        public ActionResult GetDate()
        {
            return Content(DateTime.Now.ToShortDateString());
        }
    }
}