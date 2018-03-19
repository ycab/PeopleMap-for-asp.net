using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace peopleMap
{
    /// <summary> 
    /// 权限验证 
    /// </summary> 
    public class AuthAttribute : ActionFilterAttribute
    {
        /// <summary> 
        /// 角色名称 
        /// </summary> 
        public string Code { get; set; }
        /// <summary> 
        /// 验证权限（action执行前会先执行这里） 
        /// </summary> 
        /// <param name="filterContext"></param> 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /* 如果登录不成功的话，跳转到登录页面*/
            if (filterContext.HttpContext.Session["userName"] == null)
            {
                filterContext.HttpContext.Response.Redirect("../Login/UserLogin");
            }
         
        }
    }
}