using System;
using System.Collections.Generic;
using peopleMap.Service;
using peopleMap.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace peopleMap.Controllers
{
    [AuthAttribute]
    public class MapController : Controller
    {
        //
        // GET: /Map/ 进入世界地图的页面
        public ActionResult GetMap()
        {
            return View();
        }

        /*
         根据类别获得相应国家的人数。
         */
        public string getData()
        {
            string sslb = Request.Form["sslb"].ToString();
            MapService service = new MapService();
            IList<Count> users = service.getData(sslb);
            string json = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        public ActionResult GetChina()
        {
            return View();
        }
	}
}