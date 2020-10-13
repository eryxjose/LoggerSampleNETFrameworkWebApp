using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogApp.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Index(Exception error)
        {
            Response.StatusCode = 500;
            return View("Error", error);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public ViewResult NotFound(Exception error)
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("NotFound", error);
        }

        public ViewResult NotAuthorized(Exception error)
        {
            Response.StatusCode = 401;  //you may want to set this to 200
            return View("NotAuthorized", error);
        }
    }
}