using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace peopleMap.Models
{
    public class RankData
    {
         public virtual string RCID { get; set; }
        public virtual string SSLB { get; set; }
        public virtual string SSZL { get; set; }
        public virtual string RCLB { get; set; }
        public virtual string RCNAME { get; set; }
        public virtual string SEX { get; set; }
        public virtual string SZJG { get; set; }
        public virtual string COUNTRY { get; set; }

        public virtual string ZC { get; set; }

        public virtual string ZW { get; set; }

        public virtual int ZLNUMBER { get; set; }
        public virtual string YJFX { get; set; }

        public virtual decimal RANK { get; set; }
    }
}