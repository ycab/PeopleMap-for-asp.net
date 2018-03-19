using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using peopleMap.Service;
namespace peopleMap.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult UserLogin()
        {
            Session.Clear();
            return View();
        }
        public ActionResult CheckInfo()
        {
            var account = Request["username"];
            var pwd = Request["pwd"];
            Session["userName"] = account;
            string authority = "0";
            authority = new UserService().CheckAccountInfo(account, pwd);
            if (authority == "fail")
            {
                return Content("fail");
            }
            else
            {
                Session["authority"] = authority;
                return Content("ok");
            }

        }
    }
}