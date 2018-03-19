using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using peopleMap.Models;
using peopleMap.Dao;

namespace peopleMap.Service
{
    public class UserService:IUserService
    {
        public string CheckAccountInfo(string userName, string pwd)
        {
            IUserDao UserDao = new UserDao();
            IList<User> userlist = UserDao.FindAccountInfo(userName, pwd);
            if (userlist.Count() == 0)
            {
                return "fail";
            }
            else
            {
                User user = userlist.FirstOrDefault();
                return user.Authority;
            }


        }

        public bool CreatUser(User user)
        {
            return false;
        }
        public bool EditUserInfo(User user)
        {
            IUserDao UserDao = new UserDao();
            string ID = user.UserID;
            IList<User> userlist = UserDao.FindAccountInfoByID(ID);
            User user1 = userlist.FirstOrDefault();
            user1 = user;
            UserDao.Update(user1);
            return true;

        }
        public bool AddUser(User user)
        {
            IUserDao UserDao = new UserDao();
            user.UserID = Guid.NewGuid().ToString("N");
            var obj = UserDao.Save(user);
            return true;
        }
        public bool DeleteUser(string ID)
        {
            IUserDao UserDao = new UserDao();
            IList<User> userlist = UserDao.FindAccountInfoByID(ID);
            User user1 = userlist.FirstOrDefault();
            UserDao.Delete(user1);
            return true;
        }
        public IList<User> SearchUser(string field, string op, string data)
        {
            if (field == "Username")
            {
                IUserDao UserDao = new UserDao();
                IList<User> user = UserDao.FindAccountInfoByUsername(data);
                return user;
            }
            else if (field == "Email")
            {
                IUserDao UserDao = new UserDao();
                IList<User> user = UserDao.FindAccountInfoByContact(data);
                return user;
            }
            else if (field == "Gender")
            {
                IUserDao UserDao = new UserDao();
                IList<User> user = UserDao.FindAccountInfoByGender(data);
                return user;
            }
            else if (field == "Authority")
            {
                IUserDao UserDao = new UserDao();
                IList<User> user = UserDao.FindAccountInfoByAuthority(data);
                return user;
            }
            else
            {
                IList<User> user = null;
                return user;
            }
        }
        public string EditUserPwd(string userName, string oldpwd, string newpwd)
        {
            IUserDao UserDao = new UserDao();
            IList<User> userlist = UserDao.FindAccountInfo(userName, oldpwd);
            if (userlist.Count() == 0)
            {
                return "0";
            }
            else
            {
                User user = userlist.FirstOrDefault();
                user.Pwd = newpwd;
                UserDao.Update(user);
                return "success";
            }
        }
    }
}