﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using peopleMap.Dao;
using peopleMap.Models;

namespace peopleMap.Service
{
    public class RankService
    {
        static Dictionary<string, string> countrys = new Dictionary<string, string>{  
         {"安哥拉","Angola"},{"阿富汗","Afghanistan"},
        {"阿尔巴尼亚","Albania"},
        {"阿尔及利亚","Algeria"},{"安道尔共和国","Andorra"},{"安圭拉岛","Anguilla"},
        {"安提瓜和巴布达","Barbuda Antigua"},{"阿根廷","Argentina"},{"亚美尼亚","Armenia"},
        {"澳大利亚","Australia"},{"奥地利","Austria"},{"阿塞拜疆","Azerbaijan"},
        {"巴哈马","Bahamas"},{"巴林","Bahrain"},{"孟加拉国","Bangladesh"},{"巴巴多斯","Barbados"},
        {"白俄罗斯","Belarus"},{"比利时","Belgium"},{"伯利兹","Belize"},{"贝宁","Benin"},
        {"百慕大群岛","Bermuda Is."},{"玻利维亚","Bolivia"},{"博茨瓦纳","Botswana"},{"巴西","Brazil"},
        {"文莱","Brunei"},{"保加利亚","Bulgaria"},{"布基纳法索","Burkina-faso"},{"缅甸","Burma"},
        {"布隆迪","Burundi"},{"喀麦隆","Cameroon"},{"加拿大","Canada"},
        {"中非共和国","Central African Republic"},{"乍得","Chad"},{"智利","Chile"},{"中国","China"},
        {"哥伦比亚","Colombia"},{"刚果","Congo"},{"库克群岛","Cook Is."},{"哥斯达黎加","Costa Rica"},
        {"古巴","Cuba"},{"塞浦路斯","Cyprus"},{"捷克","Czech Republic"},{"丹麦","Denmark"},{"吉布提","Djibouti"},
        {"多米尼加共和国","Dominica Rep."},{"厄瓜多尔","Ecuador"},{"埃及","Egypt"},{"萨尔瓦多","EI Salvador"},
        {"爱沙尼亚","Estonia"},{"埃塞俄比亚","Ethiopia"},{"斐济","Fiji"},{"芬兰","Finland"},{"法国","France"},
        {"法属圭亚那","French Guiana"},{"加蓬","Gabon"},{"冈比亚","Gambia"},{"格鲁吉亚","Georgia"},
        {"德国","Germany"},{"加纳","Ghana"},{"直布罗陀","Gibraltar"},{"希腊","Greece"},{"格林纳达","Grenada"},
        {"关岛","Guam"},{"危地马拉","Guatemala"},{"几内亚","Guinea"},{"圭亚那","Guyana"},{"海地","Haiti"},
        {"洪都拉斯","Honduras"},{"香港","Hongkong"},{"匈牙利","Hungary"},{"冰岛","Iceland"},{"印度","India"},
        {"印度尼西亚","Indonesia"},{"伊朗","Iran"},{"伊拉克","Iraq"},{"爱尔兰","Ireland"},{"以色列","Israel"},
        {"意大利","Italy"},{"牙买加","Jamaica"},{"日本","Japan"},{"约旦","Jordan"},
        {"柬埔寨","Kampuchea (Cambodia )"},{"哈萨克斯坦","Kazakstan"},{"肯尼亚","Kenya"},
        {"韩国","Korea"},{"科威特","Kuwait"},{"吉尔吉斯坦","Kyrgyzstan"},{"老挝","Laos"},
        {"拉脱维亚","Latvia"},{"黎巴嫩","Lebanon"},{"莱索托","Lesotho"},{"利比里亚","Liberia"},
        {"利比亚","Libya"},{"列支敦士登","Liechtenstein"},{"立陶宛","Lithuania"},{"卢森堡","Luxembourg"},
        {"澳门","Macao"},{"马达加斯加","Madagascar"},{"马拉维","Malawi"},{"马来西亚","Malaysia"},
        {"马尔代夫","Maldives"},{"马里","Mali"},{"马耳他","Malta"},{"毛里求斯","Mauritius"},
        {"墨西哥","Mexico"},{"摩尔多瓦","Moldova"},{"摩纳哥","Monaco"},{"蒙古","Mongolia"},
        {"蒙特塞拉特岛","Montserrat Is."},{"摩洛哥","Morocco"},{"莫桑比克","Mozambique"},
        {"纳米比亚","Namibia"},{"瑙鲁","Nauru"},{"尼泊尔","Nepal"},{"荷兰","Netherlands"},
        {"新西兰","New Zealand"},{"尼加拉瓜","Nicaragua"},{"尼日尔","Niger"},{"尼日利亚","Nigeria"},
        {"朝鲜","North Korea"},{"挪威","Norway"},{"阿曼","Oman"},{"巴基斯坦","Pakistan"},
        {"巴拿马","Panama"},{"巴布亚新几内亚","Papua New Cuinea"},{"巴拉圭","Paraguay"},
        {"秘鲁","Peru"},{"菲律宾","Philippines"},{"波兰","Poland"},{"法属玻利尼西亚","French Polynesia"},
        {"葡萄牙","Portugal"},{"波多黎各","Puerto Rico"},{"卡塔尔","Qatar"},{"罗马尼亚","Romania"},
        {"俄罗斯","Russia"},{"圣卢西亚","Saint Lueia"},{"圣文森特岛","Saint Vincent"},
        {"圣马力诺","San Marino"},{"圣多美和普林西比","Sao Tome and Principe"},
        {"沙特阿拉伯","Saudi Arabia"},{"塞内加尔","Senegal"},{"塞舌尔","Seychelles"},
        {"塞拉利昂","Sierra Leone"},{"新加坡","Singapore"},{"斯洛伐克","Slovakia"},
        {"斯洛文尼亚","Slovenia"},{"所罗门群岛","Solomon Is."},{"索马里","Somali"},
        {"南非","South Africa"},{"西班牙","Spain"},{"斯里兰卡","Sri Lanka"},
        {"苏丹","Sudan"},{"苏里南","Suriname"},{"斯威士兰","Swaziland"},
        {"瑞典","Sweden"},{"瑞士","Switzerland"},{"叙利亚","Syria"},
        {"台湾省","Taiwan"},{"塔吉克斯坦","Tajikstan"},{"坦桑尼亚","Tanzania"},
        {"泰国","Thailand"},{"多哥","Togo"},{"汤加","Tonga"},
        {"特立尼达和多巴哥","Trinidad and Tobago"},{"突尼斯","Tunisia"},{"土耳其","Turkey"},
        {"土库曼斯坦","Turkmenistan"},{"乌干达","Uganda"},{"乌克兰","Ukraine"},
        {"阿拉伯联合酋长国","United Arab Emirates"},{"英国","United Kiongdom"},
        {"美国","United States"},{"乌拉圭","Uruguay"},{"乌兹别克斯坦","Uzbekistan"},
        {"委内瑞拉","Venezuela"},{"越南","Vietnam"},{"也门","Yemen"},{"南斯拉夫","Yugoslavia"},
        {"津巴布韦","Zimbabwe"},{"扎伊尔","Zaire"},{"赞比亚","Zambia"},{"波黑共和国","Bosnia and Herzegovina"},
      };
        public void saveData(Data data)
        {
            RankDao rankDao = new RankDao();
            string country = data.COUNTRY.Replace(" ","");
            string name = countrys[country];
            string sslb = data.SSLB;
            IList<Count> lists = rankDao.getCount(name, sslb);
            if (lists.Count == 0)
            {
                insertCount(name, sslb);
            }
            else
            {
                Count count = new Count();
                foreach (Count c in lists)
                {
                    count = c;
                }
                count.value++;
                updateCount(count);
            }
             if (name == "China")
            {
                string sf = data.SF;
                string sslb1 = data.SSLB+"cn";
                IList<Count> sfs = rankDao.getCount(sf, sslb1);
                if (sfs.Count == 0)
                {
                    insertCount(sf, sslb1);
                }
                else
                {
                    Count count = new Count();
                    foreach (Count c in sfs)
                    {
                        count = c;
                    }
                    count.value++;
                    updateCount(count);
                }
             }
        }

        //删除数据
         public void deleteData(string id)
        {
            MapDao dao = new MapDao();
            RankDao rankDao = new RankDao();
           Data data= dao.getDataModel(id);
           string country = data.COUNTRY;
           string name=countrys[country];
           string sf = data.SF;
           string sslb = data.SSLB;
            IList<Count> lists = rankDao.getCount(name, sslb);
            Count count = new Count();
            foreach (Count c in lists)
            {
                count = c;
            }
            count.value--;
            updateCount(count);

            if (name == "China")
            {
                string sslb1 = data.SSLB + "cn";
                IList<Count> sfs = rankDao.getCount(sf, sslb1);
                Count count1= new Count();
                foreach (Count c in sfs)
                {
                    count1 = c;
                }
                count1.value--;
                updateCount(count1);
            }
            dao.deleteData(id);
        }

        public void updateCount(Count count)
        {
            RankDao rankDao = new RankDao();
            rankDao.updateCount(count);
        }

        public void insertCount(string name, string sslb)
        {
            RankDao rankDao = new RankDao();
            Count count = new Count();
            count.COUNTID = Guid.NewGuid().ToString();
            count.name = name;
            count.SSLB = sslb;
            count.value = 1;
            rankDao.insertCount(count);
        }

        public  IList<Data> getDataDetail(string RCID)
        {
            return new RankDao().getDataDetail(RCID);
        }

        public IList<RCQZ> getRankSet()
        {
            return new RankDao().getRankSet();
        }


        internal IList<RCQZ> updateRank(string QZID)
        {
            throw new NotImplementedException();
        }

        public string updateQZ(QZModel rcqz)
        {

            string[] qzs ={
                         rcqz.ZCQZ,
                         rcqz.YS,
                         rcqz.JS,
                         rcqz.FJS,
                         rcqz.YJY,
                         rcqz.QT,
                         rcqz.TXQZ,
                         rcqz.YS1,
                         rcqz.CJXZ,
                         rcqz.QRJH,
                         rcqz.JCQN,
                         rcqz.QT1,
                         rcqz.ZWQZ,
                         rcqz.ZWJF,
                         rcqz.ZLQZ,
                         rcqz.ZLJF
                        };

            return new RankDao().updateQZ(qzs);
        }
    }
}