using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using peopleMap.App_Start;
namespace peopleMap.Dao
{
    public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        public NHibernateHelper()
        {
            //创建ISessionFactory
            _sessionFactory = GetSessionFactory();
        }

        /// <summary>
        /// 创建ISessionFactory
        /// </summary>
        /// <returns></returns>
        public ISessionFactory GetSessionFactory()
        {
            //配置ISessionFactory
            return (new Configuration()).Configure().BuildSessionFactory();
        }

        /// <summary>
        /// 打开ISession
        /// </summary>
        /// <returns></returns>
        public ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }
        public ISession GetSession2()
        {
            return _sessionFactory.OpenSession(new SQLWatcher());
        }
    }
}