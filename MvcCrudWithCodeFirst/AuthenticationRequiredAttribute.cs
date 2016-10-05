using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudWithCodeFirst
{
    public class AuthenticationRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (System.Web.HttpContext.Current.Session["User"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("/Authentication/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}