using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autentals.Controllers
{
    [RoutePrefix("Error")]
    public class ErrorController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View("Error");
        }

        //Need to create this view
        [Route("NotFound")]
        public ActionResult NotFound()
        {
            Response.StatusCode = 200;
            return View("NotFound");
        }

        //Need to create this view
        [Route("InternalServer")]
        public ActionResult InternalServer()
        {
            Response.StatusCode = 200;
            return View("InternalServer");
        }
    }
}