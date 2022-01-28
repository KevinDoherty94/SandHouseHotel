using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolTour.Controllers
{
    public class ActivitiesController : Controller
    {
        // GET: Activities
        public ActionResult Surfing()
        {
            return View();
        }

        public ActionResult WildAtlanticWay()
        {
            return View();
        }

        public ActionResult SiteSeeing()
        {
            return View();
        }
    }
}