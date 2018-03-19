using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Bytecode;
using peopleMap.Dao;
using peopleMap.Models;
using peopleMap.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit;
using NUnit.Framework;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;
using System.Data.OleDb;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
namespace peopleMap.Controllers
{
    [AuthAttribute]
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult UserManage()
        {
            return View();
        }
        public ActionResult UserManage2()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            //Session["userName"] = "fffff";
            return View();
        }
        public ActionResult UserCodeEdit()
        {
            return View();
        }
        public class NHiberTest
        {
            [Test]
            public void InitTest()
            {
                var cfg = new NHibernate.Cfg.Configuration().Configure(System.AppDomain.CurrentDomain.BaseDirectory + "hibernate.cfg.xml");
                using (ISessionFactory sessionFactory = cfg.BuildSessionFactory()) { }
            }
        }

        public void SaveTest()
        {
            IUserDao productDao = new UserDao();

            var product = new User
            {
                UserID = Guid.NewGuid().ToString("N"),
                Username = "yp",
                Pwd = "123",
                //  Email = "电脑",
                Gender = "男",
                Authority = "普通用户",
            };

            // var obj = new ProductDao().Save(product);
            var obj = productDao.Save(product);

        }

        public string GetList()
        {
            //   string userName = "yupeng";
            //   string userName2 = "yp";
            //   String pwd = "123";
            //   string id="3";
            //   IUserDao UserDao = new UserDao();
            //   IList<User> user = UserDao.FindAccountInfo(userName,pwd);
            //   IList<User> user2 = UserDao.FindAccountInfo(userName, pwd);
            ////   IList<User> userb=
            //   IList<User> Result = user.Union(user2).ToList<User>();
            //   string json = JsonConvert.SerializeObject(Result);
            //   return json;
            string search = Request["_search"];
            if (search == "false")
            {
                IUserDao UserDao = new UserDao();
                string autho = "1";
                IList<User> user = UserDao.FindAccountInfoByAuthority(autho);
                foreach (User u in user)
                {
                    u.Authority = "管理员";
                }
                string json = JsonConvert.SerializeObject(user);
                return json;
            }
            else
            {
                string filters = Request["filters"];
                JObject jo = JObject.Parse(filters);
                JArray rulesArray = JArray.Parse(jo["rules"].ToString());
                JObject rules_0 = JObject.Parse(rulesArray[0].ToString());
                string field = rules_0["field"].ToString();
                string op = rules_0["op"].ToString();
                string data = rules_0["data"].ToString();
                IUserService userservice = new UserService();
                IList<User> user = userservice.SearchUser(field, op, data);

                string json = JsonConvert.SerializeObject(user);
                return json;
            }


        }
        public string GetList2()
        {
            //   string userName = "yupeng";
            //   string userName2 = "yp";
            //   String pwd = "123";
            //   string id="3";
            //   IUserDao UserDao = new UserDao();
            //   IList<User> user = UserDao.FindAccountInfo(userName,pwd);
            //   IList<User> user2 = UserDao.FindAccountInfo(userName, pwd);
            ////   IList<User> userb=
            //   IList<User> Result = user.Union(user2).ToList<User>();
            //   string json = JsonConvert.SerializeObject(Result);
            //   return json;
            string search = Request["_search"];
            if (search == "false")
            {
                IUserDao UserDao = new UserDao();
                string autho = "2";
                IList<User> user = UserDao.FindAccountInfoByAuthority(autho);
                foreach (User u in user)
                {
                    u.Authority = "普通用户";
                }
                string json = JsonConvert.SerializeObject(user);
                return json;
            }
            else
            {
                string filters = Request["filters"];
                JObject jo = JObject.Parse(filters);
                JArray rulesArray = JArray.Parse(jo["rules"].ToString());
                JObject rules_0 = JObject.Parse(rulesArray[0].ToString());
                string field = rules_0["field"].ToString();
                string op = rules_0["op"].ToString();
                string data = rules_0["data"].ToString();
                IUserService userservice = new UserService();
                IList<User> user = userservice.SearchUser(field, op, data);
                foreach (User u in user)
                {
                    u.Authority = "普通用户";
                }
                string json = JsonConvert.SerializeObject(user);
                return json;
            }


        }

        //public ActionResult Edit(User pro, string oper, int id)
        public string UserEdit()
        {
            var oper = Request["oper"];
            var id = Request["id"];
            var username = Request["Username"];
            var pwd = Request["pwd"];
            var unit = Request["Unit"];
            var contact = Request["Contact"];
            var gender = Request["Gender"];
            var authority = Request["Authority"];
            //int a1 = int.Parse(gender);
            //int a2;
            //int.TryParse(gender, out a2);
            //int a3 = Convert.ToInt32(gender);
            User user = new User
            {
                UserID = id,
                Username = username,
                Pwd = pwd,
                Unit = unit,
                Gender = gender,
                Contact = contact,
                Authority = "2"
            };
            if (oper == "edit")
            {
                bool success = new UserService().EditUserInfo(user);

            }
            if (oper == "add")
            {
                bool success = new UserService().AddUser(user);
            }
            if (oper == "del")
            {
                bool success = new UserService().DeleteUser(id);
                //  bool success = new UserService().DeleteUser(user);
            }
            //User user = pro;
            //string oper1 = oper;
            //int id2 = id;
            //if (oper == "edit")
            //{
            return "success";
            //}
            //return Json(pro, JsonRequestBehavior.AllowGet);
        }
        public string ManagerEdit()
        {
            var oper = Request["oper"];
            var id = Request["id"];
            var username = Request["Username"];
            var pwd = Request["pwd"];
            var unit = Request["Unit"];
            var contact = Request["Contact"];
            var gender = Request["Gender"];
            var authority = Request["Authority"];
            //int a1 = int.Parse(gender);
            //int a2;
            //int.TryParse(gender, out a2);
            //int a3 = Convert.ToInt32(gender);
            User user = new User
            {
                UserID = id,
                Username = username,
                Pwd = pwd,
                Unit = unit,
                Gender = gender,
                Contact = contact,
                Authority = "1"
            };
            if (oper == "edit")
            {
                bool success = new UserService().EditUserInfo(user);

            }
            if (oper == "add")
            {
                bool success = new UserService().AddUser(user);
            }
            if (oper == "del")
            {
                bool success = new UserService().DeleteUser(id);
                //  bool success = new UserService().DeleteUser(user);
            }
            //User user = pro;
            //string oper1 = oper;
            //int id2 = id;
            //if (oper == "edit")
            //{
            return "success";
            //}
            //return Json(pro, JsonRequestBehavior.AllowGet);
        }
        public string Delete()
        {
            var ID = Request["UserID"];
            bool success = new UserService().DeleteUser(ID);
            return "success";
        }
        public string EditPwd()
        {

            var username = Session["userName"].ToString();
            var oldpassward = Request["oldpassward"];
            var newpassward = Request["newpassward"];
            var confirmnewpassward = Request["confirmnewpassward"];
            return new UserService().EditUserPwd(username, oldpassward, newpassward);

        }

    }
}