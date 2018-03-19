using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peopleMap.Models
{
    public class RankChinaData
    {
        public virtual string RCID { get; set; }
        public virtual string SSLB { get; set; }
        public virtual string RCLB { get; set; }
        public virtual string RCNAME { get; set; }
        public virtual string SEX { get; set; }
        public virtual string SZJG { get; set; }
        public virtual string CITY { get; set; }

        public virtual string ZC { get; set; }

        public virtual string ZW { get; set; }

        public virtual int ZLNUMBER { get; set; }
        public virtual string YJFX { get; set; }

        public virtual decimal RANK { get; set; }
    }
}