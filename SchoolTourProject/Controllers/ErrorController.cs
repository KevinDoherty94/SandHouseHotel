using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolTourProject.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Http400()
        {
            Response.StatusCode = 400; //Need to add this 
            return View();
        }

        public ActionResult Http404()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}