using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using peopleMap.Models;
using NUnit.Framework;
using NUnit;
using peopleMap.App_Start;
namespace peopleMap.Dao
{
    public class RankDao
    {
        static Dictionary<string, decimal> qzDict = new Dictionary<string, decimal>();
        
        private static NHibernateHelper nhibernateHelper ;


        static RankDao()
        {
            nhibernateHelper = new NHibernateHelper();
            getQZList();
        }

        

        public decimal getSocre(string zc, string tx, int zlNumber)
        {
            decimal zc1 = 0;
            if(zc!="" && zc!=null){
                if (zc.Contains("院士"))
                {
                    zc1 = qzDict["院士1"];
                }
                 else if (zc.Contains("教授") && zc.Contains("副教授"))
                {
                    zc1 = qzDict["副教授"]; 
                }
                else if (zc.Contains("教授"))
                {
                    zc1 = qzDict["教授"];
                }
                else if (zc.Contains("研究员"))
                {
                    zc1 = qzDict["研究员"];
                }
                else
                {
                    zc1 = qzDict["其他1"];
                }

            }
            else
            {
                zc1 = qzDict["其他1"];
            }
           
            
           
            decimal tx1 = 0;
            if (tx != "" && tx != null)
            {
                if (tx.Contains("院士") )
                {
                    tx1 = qzDict["院士2"]; 
                }
                else if (tx.Contains("长江"))
                {
                    tx1 = qzDict["长江"]; 
                }
                else if (tx.Contains("千人"))
                {
                    tx1 = qzDict["千人"]; 
                }
                else if(tx.Contains("杰青") && tx.Contains("杰出青年"))
                {
                    tx1 = qzDict["杰青"];
                }
                else
                {
                    tx1 = qzDict["其他2"];
                }
            }
            else
            {
                tx1 = qzDict["其他2"];
            }
           
            decimal zl1 = 0;
            if (zlNumber != 0)
            {
                zl1 = qzDict["专利数量"]; 
            }
            decimal zc2 = qzDict["职称"]; 
            decimal zw2 = qzDict["职务"];  //变成获奖
            decimal tx2 = qzDict["头衔"]; 
            decimal zl2 = qzDict["专利"];

            if (zlNumber >= 30)
            {
                zlNumber = 1;
            }
            else if (zlNumber != 0)
            {
                zlNumber = zlNumber / 30;
            }

            return zc1 * zc2  + tx1 * tx2 + zlNumber * zl1 * zl2;
          
        }

     /*   public decimal getQZ(string qzName)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                decimal qz=0;
                ITransaction trans = session.BeginTransaction();
                IList<RCQZ> list = session.Query<RCQZ>().Where(qz1 => qz1.QZNAME == qzName).ToList();
                foreach (RCQZ q in list)
                {
                    qz = q.QZ;
                }
                return qz;
            }
        }*/

        public static void getQZList()
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
               
                ITransaction trans = session.BeginTransaction();
                IList<RCQZ> list = session.Query<RCQZ>().ToList();
                foreach (RCQZ q in list)
                {
                    qzDict.Add(q.QZNAME, q.QZ);
                }
            }
        }

        /*
         保存数据
         */
        public object saveData(Data data)
        {

            using (ISession session =nhibernateHelper.GetSession2())
            {
                ITransaction trans = session.BeginTransaction();
                var length = data.ZLNR.Length;
                var length2= data.PRICE.Length;
                var length3 = data.TX.Length;
                var length4 = data.ADDRESS.Length;
                var length5 = data.RCID.Length;
                var length6 = data.RCNAME.Length;
                var length7 = data.SEX.Length;
                var lenth8 = data.BIRTHDAY.Length;
                var lenth9 = data.SZJG.Length;
                var length10 = data.COUNTRY.Length;
                var length11 = data.CITY.Length;
                var length12 = data.ZC.Length;
                var length13 = data.ZW.Length;
                var length14 = data.RCURL.Length;
                var lentth15 = data.YJFX.Length;
                var lentth16= data.EMAIL.Length;
                var lentth17 = data.PHONE.Length;
                var lentth18 = data.BZ.Length;
                var id = session.Save(data);

                session.Flush();　　//执行此行代码，才真正提交到数据库
                trans.Commit();
                return id;
            }
        }

        /*
         根据国家名查询是否存在
         */
        public IList<Count> getCount(string name, string sslb)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
               IList<Count> lists= session.QueryOver<Count>().Where(c => c.name == name)
                    .And(c => c.SSLB == sslb).List();
               return lists;
            }
        }

        public void insertCount(Count count)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();

                session.Save(count);
                session.Flush();　　//执行此行代码，才真正提交到数据库
                trans.Commit();
            }
        }

        public void updateCount(Count count)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();

                session.Update(count);
                session.Flush();　　//执行此行代码，才真正提交到数据库
                trans.Commit();
            }
        }
        //查询单个详细信息
        public IList<Data> getDataDetail(string RCID)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();

                IList<Data> lists = session.QueryOver<Data>().Where(c => c.RCID == RCID).List();

             
                trans.Commit();
                return lists;
            }
        }
        //查询权值
        public IList<RCQZ> getRankSet()
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();

                var json = session.QueryOver<RCQZ>().List();

                return json;
            }
        }
        //修改权值
        public string updateQZ(string[] qzs)
        {
            qzDict["职称"] = Convert.ToDecimal(qzs[0]);
            updateRCQZ("职称", qzDict["职称"]);
            qzDict["院士1"] = Convert.ToDecimal(qzs[1]);
            updateRCQZ("院士1", qzDict["院士1"]);
            qzDict["教授"] = Convert.ToDecimal(qzs[2]);
            updateRCQZ("教授", qzDict["教授"]);
            qzDict["副教授"] = Convert.ToDecimal(qzs[3]);
            updateRCQZ("副教授", qzDict["副教授"]);
            qzDict["研究员"] = Convert.ToDecimal(qzs[4]);
            updateRCQZ("研究员", qzDict["研究员"]);
            qzDict["其他1"] = Convert.ToDecimal(qzs[5]);
            updateRCQZ("其他1", qzDict["其他1"]);
            qzDict["头衔"] = Convert.ToDecimal(qzs[6]);
            updateRCQZ("头衔", qzDict["头衔"]);
            qzDict["院士2"] = Convert.ToDecimal(qzs[7]);
            updateRCQZ("院士2", qzDict["院士2"]);
            qzDict["长江"] = Convert.ToDecimal(qzs[8]);
            updateRCQZ("长江", qzDict["长江"]);
            qzDict["千人"] = Convert.ToDecimal(qzs[9]);
            updateRCQZ("千人", qzDict["千人"]);
            qzDict["杰青"] = Convert.ToDecimal(qzs[10]);
            updateRCQZ("杰青", qzDict["杰青"]);
            qzDict["其他2"] = Convert.ToDecimal(qzs[11]);
            updateRCQZ("其他2", qzDict["其他2"]);
            qzDict["职务"] = Convert.ToDecimal(qzs[12]);
            updateRCQZ("职务", qzDict["职务"]);
            qzDict["职务1"] = Convert.ToDecimal(qzs[13]);
            updateRCQZ("职务1", qzDict["职务1"]);
            qzDict["专利"] = Convert.ToDecimal(qzs[14]);
            updateRCQZ("专利", qzDict["专利"]);
            qzDict["专利数量"] = Convert.ToDecimal(qzs[15]);
            updateRCQZ("专利数量", qzDict["专利数量"]);

            return "success";
        }

        public void updateRCQZ(string qzname, decimal qz)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<RCQZ> list = session.Query<RCQZ>().Where(qz1 => qz1.QZNAME == qzname).ToList();
                RCQZ rcqz = new RCQZ();
                foreach (RCQZ q in list)
                {
                    rcqz = q;
                }
                rcqz.QZ = qz;
                session.Update(rcqz);
                session.Flush();
                trans.Commit();

            }
        }


        public decimal getPriceSocre(string price)
        {
            decimal x = 0.03M;
            int count = 0;
            if (price != null && price != "")
            {
                string[] strs = price.Split('；');
                foreach (String s in strs)
                {
                    string[] strs2 = s.Split('，');
                    foreach (string str in strs2)
                    {
                        string[] strs3 = str.Split('、');
                        count += strs3.Length;
                    }
                }
            }
            decimal zw1 = 0;
           
            zw1 = qzDict["职务1"];   //变成获奖 10
          
            return count * x * zw1;
        }
    }
}