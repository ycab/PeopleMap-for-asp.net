using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using peopleMap.Models;

namespace peopleMap.Dao
{
    public class UserDao : IUserDao
    {
        private NHibernateHelper nhibernateHelper ;
        private ISessionFactory sessionFactory;
        public UserDao()
        {
           nhibernateHelper = new NHibernateHelper();
        }

        public object Save(User user)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                var id = session.Save(user);
                session.Flush();　　//执行此行代码，才真正提交到数据库
                trans.Commit();
                return id;
            }
        }


        public void Update(User user)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                session.Update(user);
                session.Flush();
                trans.Commit();
            }
        }

        public void Delete(User user)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                session.Delete(user);
                session.Flush();　　//执行此行代码，才真正提交到数据库
                trans.Commit();
            }
        }



        public IList<User> LoadAll()
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<User> users = session.QueryOver<User>().List();
                trans.Commit();
                return users;
            }
        }


        public IList<User> FindAccountInfoByID(string ID)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<User> users = session.QueryOver<User>().Where(user => user.UserID == ID).List();
                trans.Commit();
                return users;
            }
        }
        public IList<User> FindAccountInfoByUsername(string userName)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<User> users = session.QueryOver<User>().Where(user => user.Username == userName).List();
                trans.Commit();
                return users;
            }
        }
        public IList<User> FindAccountInfoByGender(string Gender)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<User> users = session.QueryOver<User>().Where(user => user.Gender== Gender).List();
                trans.Commit();
                return users;
            }
        }
        public IList<User> FindAccountInfoByAuthority(string Authority)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<User> users = session.QueryOver<User>().Where(user => user.Authority== Authority).List();
                trans.Commit();
                return users;
            }
        }

        public IList<User> FindAccountInfoByUsernameAndAuthority(string userName, string Authority)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<User> users = session.QueryOver<User>().Where(user => user.Username == userName).And(user => user.Authority== Authority).List();
                trans.Commit();
                return users;
            }
        }
        public IList<User> FindAccountInfoByContact(string Contact)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<User> users = session.QueryOver<User>().Where(user => user.Contact== Contact).List();
                trans.Commit();
                return users;
            }
        }
        public IList<User> FindAccountInfo(string userName, string pwd)
        {
            using (ISession session = nhibernateHelper.GetSession())
            {
                ITransaction trans = session.BeginTransaction();
                IList<User> users = session.QueryOver<User>().Where(user => user.Username == userName).And(user => user.Pwd == pwd).List();
                trans.Commit();
                return users;
            }
        }
    }
}