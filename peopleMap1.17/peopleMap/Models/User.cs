using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peopleMap.Models
{
   public class User
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual string UserID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public virtual string Username { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string  Pwd{ get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Unit { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        /// 
        public virtual string Contact { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual string Gender { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual string Authority { get; set; }

        /// <summary>
        /// 权限
        /// </summary>

    }
}
