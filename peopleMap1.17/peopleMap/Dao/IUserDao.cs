using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using peopleMap.Models;

namespace peopleMap.Dao
{
    interface IUserDao
    {
        object Save(User entity);

        void Update(User entity);

        void Delete(User entity);

        IList<User> LoadAll();

        IList<User> FindAccountInfo(string userName, string pwd);

        IList<User> FindAccountInfoByID(string ID);

        IList<User> FindAccountInfoByUsername(string userName);

        IList<User> FindAccountInfoByGender(string Gender);

        IList<User> FindAccountInfoByAuthority(string Authority);

        IList<User> FindAccountInfoByContact(string Contact);

        IList<User> FindAccountInfoByUsernameAndAuthority(string userName, string Authority);
    }
}
