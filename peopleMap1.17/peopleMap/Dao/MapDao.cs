using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using peopleMap.Models;
using NUnit.Framework;
using NUnit;
namespace peopleMap.Dao
{
     [TestFixture]
    public class MapDao
    {

        private NHibernateHelper nhibernateHelper ;
        public MapDao()
        {
           nhibernateHelper = new NHibernateHelper();
        }

        public object saveData(Data data)
        {

            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                var id = session.Save(data);
                session.Flush();　　//执行此行代码，才真正提交到数据库
                trans.Commit();
                return id;
            }
        }

        public IList<Data> getModelList()
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<Data> datas = session.QueryOver<Data>().List();
                trans.Commit();
                return datas;
            }
        }



        public IList<Count> getData(string sslb)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<Count> counts = session.QueryOver<Count>().Where(count=>count.SSLB==sslb).List();
                trans.Commit();

                return counts;

            }
        }

        public void deleteData(string id)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                Data data=session.Get<Data>(id);
                session.Delete(data);
                session.Flush();　　//执行此行代码，才真正提交到数据库
                trans.Commit();
            }
        }

        public void Update(Data entity)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                session.Update(entity);
                session.Flush();
                trans.Commit();
            }
        }

        public IList<Data> getModelListBySF(string sf)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<Data> datas = session.QueryOver<Data>().Where(data => data.SF == sf).List();
                trans.Commit();
                return datas;
            }
        }
        public IList<Data> getModelListBySSLB(string SSLB)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<Data> datas = session.QueryOver<Data>().Where(data => data.SSLB == SSLB).List();
                trans.Commit();
                return datas;
            }
        }

        public Data getDataModel(string id)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {

                Data data = session.Get<Data>(id);

                return data;
              
            }
        }
        public IList<Data> getModelListBySSLBAndSSZL(string SSLB, string SSZL)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<Data> datas = session.QueryOver<Data>().Where(data => data.SSLB == SSLB).And(data => data.SSZL == SSZL).List();
                trans.Commit();
                return datas;
            }
        }
    }

}