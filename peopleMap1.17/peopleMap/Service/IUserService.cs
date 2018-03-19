using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using peopleMap.Models;
using peopleMap.Dao;
namespace peopleMap.Service
{
    interface IUserService
    {

        string CheckAccountInfo(string userName, string pwd);
        bool CreatUser(User user);
        bool EditUserInfo(User user);
        bool AddUser(User user);
        bool DeleteUser(string ID);
        IList<User> SearchUser(string field, string op, string data);
        string EditUserPwd(string userName, string oldpwd, string newpwd);
    }
}
