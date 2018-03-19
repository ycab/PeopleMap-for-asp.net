using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
/*

 */
namespace peopleMap.Models
{
    public class Count
    {
        [JsonIgnore]
        public virtual string COUNTID { get; set; }
        [JsonIgnore]
        public virtual string SSLB { get; set; } 
        public virtual string name { get; set; }
        public virtual int value { get; set; }
      
    }
}