using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using peopleMap.Dao;
using peopleMap.Models;

namespace peopleMap.Service
{
    public class MapService
    {
         
        /*
         根据类别得到相应的人才个数
         */
        public IList<Count> getData(string sslb)
        {
            MapDao dao = new MapDao();
            IList<Count> counts=dao.getData(sslb);
            return counts;
        }

        /*删除数据的业务*/
       
    }
}