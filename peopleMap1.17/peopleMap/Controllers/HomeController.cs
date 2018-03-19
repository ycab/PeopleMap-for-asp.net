using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace peopleMap.Controllers
{
    public class HomeController : Controller
    {
        [AuthAttribute]
        public ActionResult Index()
        {
            Session["sf"] = "江苏";
            return View();
        }

    }
}