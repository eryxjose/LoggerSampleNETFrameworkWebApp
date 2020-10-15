using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogApp.Controllers
{
    public class ErrorController : Controller
    {
        /*
            Endpoints referênciados no evento Application_Error() em Global.asax 
            para exibir mensagens de erro amigáveis
        */
        public ActionResult Index(Exception error)
        {
            Response.StatusCode = 500;
            return View("Index", error);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public ViewResult NotFound(Exception error)
        {
            Response.StatusCode = 404;
            return View("NotFound", error);
        }

        public ViewResult NotAuthorized(Exception error)
        {
            Response.StatusCode = 401;
            return View("NotAuthorized", error);
        }
    }
}