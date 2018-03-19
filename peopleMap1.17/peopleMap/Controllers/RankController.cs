using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Bytecode;
using peopleMap.Dao;
using peopleMap.Models;
using peopleMap.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit;
using NUnit.Framework;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;
using System.Data.OleDb;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
namespace peopleMap.Controllers
{

    public class RankController : Controller
    {
        public ActionResult GetRank()
        {
            return View();
        }
        public ActionResult RankEdit()
        {
            return View();
        }
        public ActionResult GetRankByRobot()
        {
            return View();
        }
        public ActionResult GetRankBy3D()
        {
            return View();
        }
        public ActionResult GetRankByCNC()
        {
            return View();
        }
        public ActionResult GetRankBySSZL()
        {
            var sub = Request["SSZL"];
            string sslb=null;
            string sszl=null;
            if (sub == "robotsub1")
            {
                sslb = "智能机器人";
                sszl = "测试1类";
            }
            else if (sub == "robotsub2")
            {
                sslb = "智能机器人";
                sszl = "测试2类";
            }
            else if (sub == "robotsub3")
            {
                sslb = "智能机器人";
                sszl = "测试3类";
            }
            else if (sub == "3Dsub1")
            {
                sslb = "3D打印";
                sszl = "测试1类";
            }
            else if (sub == "3Dsub2")
            {
                sslb = "3D打印";
                sszl = "测试2类";
            }
            else if (sub == "3Dsub3")
            {
                sslb = "3D打印";
                sszl = "测试3类";
            }
            else if (sub == "CNCsub1")
            {
                sslb = "高档数控机床";
                sszl = "测试1类";
            }
            else if (sub == "CNCsub2")
            {
                sslb = "高档数控机床";
                sszl = "测试2类";
            }
            else if (sub == "CNCsub3")
            {
                sslb = "高档数控机床";
                sszl = "测试3类";
            }
            Session["SSLB"] = sslb;
            Session["SSZL"] = sszl;
            return View();
        }

        /*
         得到所有数据之后，还要进行一次打分处理。
         */

        public string getAll()
        {
            decimal score = 0;
            RankDao rank = new RankDao();
            string var = Request.ToString();
            MapDao dao=new MapDao();
            IList<Data> datas = dao.getModelList();
            List<RankData> rankDatas = new List<RankData>();
            
            RankData rankData;
            foreach (Data data in datas)
            {
                decimal priceSocre = rank.getPriceSocre(data.PRICE);
                score = rank.getSocre(data.ZC, data.TX, data.ZLNUMBER) + priceSocre;
                rankData = new RankData();
                rankData.RCID = data.RCID;
                rankData.SSLB = data.SSLB;
                rankData.SSZL = data.SSZL;
                rankData.RCLB = data.RCLB;
                rankData.RCNAME = data.RCNAME;
                rankData.SEX = data.SEX;
                rankData.SZJG = data.SZJG;
                rankData.COUNTRY = data.COUNTRY;
                rankData.ZW = data.ZW;
                rankData.ZC = data.ZC;
                rankData.ZLNUMBER = data.ZLNUMBER;
                rankData.YJFX = data.YJFX;
                rankData.RANK = score;
                rankDatas.Add(rankData);
            }
            /*
             C#中list排序 ，正排序如图，使用lambda表达式，根据字段rank排序，
             * 如果需要反序，前面加一个负号
             */
            rankDatas.Sort((RankData x, RankData y) => { return - x.RANK.CompareTo(y.RANK); });
            string json = JsonConvert.SerializeObject(rankDatas, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        //根据所属类别得到数据并进行排序
        //所属类别有3D打印、智能机器人、高档数控机床
        public string GetBySSLB()
        {
            var sslb = Request["SSLB"];
            decimal score = 0;
            RankDao rank = new RankDao();
            string var = Request.ToString();
            MapDao dao = new MapDao();
            IList<Data> datas = dao.getModelListBySSLB(sslb);
            List<RankData> rankDatas = new List<RankData>();
            RankData rankData;
            foreach (Data data in datas)
            {
                decimal priceSocre = rank.getPriceSocre(data.PRICE);
                score = rank.getSocre(data.ZC,  data.TX, data.ZLNUMBER) + priceSocre;
                rankData = new RankData();
                rankData.RCID = data.RCID;
                rankData.SSLB = data.SSLB;
                rankData.SSZL = data.SSZL;
                rankData.RCLB = data.RCLB;
                rankData.RCNAME = data.RCNAME;
                rankData.SEX = data.SEX;
                rankData.SZJG = data.SZJG;
                rankData.COUNTRY = data.COUNTRY;
                rankData.ZW = data.ZW;
                rankData.ZC = data.ZC;
                rankData.ZLNUMBER = data.ZLNUMBER;
                rankData.YJFX = data.YJFX;
                rankData.RANK = score;
                rankDatas.Add(rankData);
            }
            /*
             C#中list排序 ，正排序如图，使用lambda表达式，根据字段rank排序，
             * 如果需要反序，前面加一个负号
             */
            rankDatas.Sort((RankData x, RankData y) => { return -x.RANK.CompareTo(y.RANK); });
            string json = JsonConvert.SerializeObject(rankDatas, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        //在所属类别的条件下，再根据所属子类来获取数据
        public string GetBySSZL()
        {
            var sszl = Session["SSZL"].ToString();
            var sslb= Session["SSLB"].ToString();
            decimal score = 0;
            RankDao rank = new RankDao();
            string var = Request.ToString();
            MapDao dao = new MapDao();
            IList<Data> datas = dao.getModelListBySSLBAndSSZL(sslb,sszl);
            List<RankData> rankDatas = new List<RankData>();
            RankData rankData;
            foreach (Data data in datas)
            {
                decimal priceSocre = rank.getPriceSocre(data.PRICE);
                score = rank.getSocre(data.ZC,  data.TX, data.ZLNUMBER) + priceSocre;
                rankData = new RankData();
                rankData.RCID = data.RCID;
                rankData.SSLB = data.SSLB;
                rankData.SSZL = data.SSZL;
                rankData.RCLB = data.RCLB;
                rankData.RCNAME = data.RCNAME;
                rankData.SEX = data.SEX;
                rankData.SZJG = data.SZJG;
                rankData.COUNTRY = data.COUNTRY;
                rankData.ZW = data.ZW;
                rankData.ZC = data.ZC;
                rankData.ZLNUMBER = data.ZLNUMBER;
                rankData.YJFX = data.YJFX;
                rankData.RANK = score;
                rankDatas.Add(rankData);
            }
            /*
             C#中list排序 ，正排序如图，使用lambda表达式，根据字段rank排序，
             * 如果需要反序，前面加一个负号
             */
            rankDatas.Sort((RankData x, RankData y) => { return -x.RANK.CompareTo(y.RANK); });
            string json = JsonConvert.SerializeObject(rankDatas, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }



        // GET: /Rank/  删除表格数据的

        public string edit()
        {
            string ids = Request["id"].ToString();
            RankService service = new RankService();
            string[] str = ids.Split(',');
            for (int i = 0; i < str.Count(); i++)
            {
                service.deleteData(str[i]);
            }

            return "suceess";

        }

      

        public string addData(Data data)
        {
            data.RCID = "a"+Guid.NewGuid().ToString("N");//保证ID号以字母开头
            RankService service = new RankService();
            service.saveData(data);
            RankDao dao = new RankDao();
            dao.saveData(data);
            return "success";

        }

        //修改数据
        public string Edit_Table(Data data)
        {
            new MapDao().Update(data);
           
            return "SUCCESS";
        }
        //详情
        public string GetTableDataDetail()
        {
            string RCID = Request["RCID"].ToString();
            string var = Request.ToString();
            RankService rankService = new RankService();
            IList<Data> client= rankService.getDataDetail(RCID);
           
            string json = JsonConvert.SerializeObject(client, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        
        //中国地图中根据省份得到人才数据
        public string getByCity()
        {
            decimal score = 0;
            RankDao rank = new RankDao();
            var sf = Request["sf"];
            if (sf == null)
            {
                sf = Session["sf"].ToString();
            }
            else
            {
                Session["sf"] = sf;
            }


            string var = Request.ToString();
            MapDao dao = new MapDao();
            IList<Data> datas = dao.getModelListBySF(sf);
            List<RankChinaData> rankChinaDatas = new List<RankChinaData>();

            RankChinaData rankChinaData;
            foreach (Data data in datas)
            {
                decimal priceSocre = rank.getPriceSocre(data.PRICE);
                score = rank.getSocre(data.ZC,  data.TX, data.ZLNUMBER) + priceSocre;
                rankChinaData = new RankChinaData();
                rankChinaData.RCID = data.RCID;
                rankChinaData.SSLB = data.SSLB;
                rankChinaData.RCLB = data.RCLB;
                rankChinaData.RCNAME = data.RCNAME;
                rankChinaData.SEX = data.SEX;
                rankChinaData.SZJG = data.SZJG;
                rankChinaData.CITY = data.CITY;
                rankChinaData.ZW = data.ZW;

                rankChinaData.ZC = data.ZC;
                rankChinaData.ZLNUMBER = data.ZLNUMBER;
                rankChinaData.YJFX = data.YJFX;
                rankChinaData.RANK = score;
                rankChinaDatas.Add(rankChinaData);
            }
            /*
             C#中list排序 ，正排序如图，使用lambda表达式，根据字段rank排序，
             * 如果需要反序，前面加一个负号
             */
            rankChinaDatas.Sort((RankChinaData x, RankChinaData y) => { return -x.RANK.CompareTo(y.RANK); });
            string json = JsonConvert.SerializeObject(rankChinaDatas, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        //获取权值设定值
        public string getRankSet()
        {
            RankService rankService = new RankService();
            IList<RCQZ> client = rankService.getRankSet();

            string json = JsonConvert.SerializeObject(client, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        //修改权重
        public string qzEdit(QZModel rcqz)
        {
            RankService rankService = new RankService();
            string flag = rankService.updateQZ(rcqz);


            return flag;
        }
        public FileResult OutExcel()//根据所属类别和所属子类导出excel
        {
            var sslb = Request["SSLB"];
            decimal score = 0;
            RankDao rank = new RankDao();
            string var = Request.ToString();
            MapDao dao = new MapDao();
            IList<Data> datas;
            if(sslb=="All")
            {
                 datas = dao.getModelList();
            }
            else 
            {
                 datas = dao.getModelListBySSLB(sslb);
            }
           
            List<DataForExcel> list = new List<DataForExcel>();

            DataForExcel rankData;
            foreach (Data data in datas)
            {
                decimal priceSocre = rank.getPriceSocre(data.PRICE);
                score = rank.getSocre(data.ZC,  data.TX, data.ZLNUMBER) + priceSocre;
                rankData = new DataForExcel();
                rankData.SSLB = data.SSLB;
                rankData.SSZL = data.SSZL;
                rankData.RCLB = data.RCLB;
                rankData.RCNAME = data.RCNAME;
                rankData.SEX = data.SEX;
                rankData.BIRTHDAY = data.BIRTHDAY;
                rankData.SZJG = data.SZJG;
                rankData.COUNTRY = data.COUNTRY;
                rankData.CITY = data.CITY;
                rankData.SF = data.SF;
                rankData.ZC = data.ZC;
                rankData.ZW = data.ZW;
                rankData.TX = data.TX;
                rankData.PRICE = data.PRICE;
                rankData.ZLNUMBER = data.ZLNUMBER;
                rankData.ZLNR = data.ZLNR;
                rankData.YJFX = data.YJFX;
                rankData.RCURL = data.RCURL;
                rankData.EMAIL = data.EMAIL;
                rankData.PHONE = data.PHONE;
                rankData.ADDRESS = data.ADDRESS;
                rankData.BZ = data.BZ;
                rankData.RANK = score;
                list.Add(rankData);
            }
            /*
             C#中list排序 ，正排序如图，使用lambda表达式，根据字段rank排序，
             * 如果需要反序，前面加一个负号
             */
            list.Sort((DataForExcel x, DataForExcel y) => { return -x.RANK.CompareTo(y.RANK); });



            //获取list数据

            IUserDao UserDao = new UserDao();
            // IList<User> list = UserDao.LoadAll();
            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("所属类别");
            //row1.CreateCell(1).SetCellValue("所属子类");
            row1.CreateCell(1).SetCellValue("人才类别");
            row1.CreateCell(2).SetCellValue("姓名");
            row1.CreateCell(3).SetCellValue("性别");
            row1.CreateCell(4).SetCellValue("出生日期");
            row1.CreateCell(5).SetCellValue("所在机构");
            row1.CreateCell(6).SetCellValue("国别");
            row1.CreateCell(7).SetCellValue("省");
            row1.CreateCell(8).SetCellValue("市");
            row1.CreateCell(9).SetCellValue("职称");
            row1.CreateCell(10).SetCellValue("职务");
            row1.CreateCell(11).SetCellValue("头衔");
            row1.CreateCell(12).SetCellValue("获奖情况");
            row1.CreateCell(13).SetCellValue("专利拥有量");
            row1.CreateCell(14).SetCellValue("专利内容");
            row1.CreateCell(15).SetCellValue("研究方向");
            row1.CreateCell(16).SetCellValue("人才URL");
            row1.CreateCell(17).SetCellValue("常用email");
            row1.CreateCell(18).SetCellValue("联系电话");
            row1.CreateCell(19).SetCellValue("通讯地址");
            row1.CreateCell(20).SetCellValue("备注");
            row1.CreateCell(21).SetCellValue("计分");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < list.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(list[i].SSLB);
                //rowtemp.CreateCell(1).SetCellValue(list[i].SSZL);
                rowtemp.CreateCell(1).SetCellValue(list[i].RCLB);
                rowtemp.CreateCell(2).SetCellValue(list[i].RCNAME);
                rowtemp.CreateCell(3).SetCellValue(list[i].SEX);
                rowtemp.CreateCell(4).SetCellValue(list[i].BIRTHDAY);
                rowtemp.CreateCell(5).SetCellValue(list[i].SZJG);
                rowtemp.CreateCell(6).SetCellValue(list[i].COUNTRY);
                rowtemp.CreateCell(7).SetCellValue(list[i].SF);
                rowtemp.CreateCell(8).SetCellValue(list[i].CITY);
                rowtemp.CreateCell(9).SetCellValue(list[i].ZC);
                rowtemp.CreateCell(10).SetCellValue(list[i].ZW);
                rowtemp.CreateCell(11).SetCellValue(list[i].TX);
                rowtemp.CreateCell(12).SetCellValue(list[i].PRICE);
                rowtemp.CreateCell(13).SetCellValue(list[i].ZLNUMBER);
                rowtemp.CreateCell(14).SetCellValue(list[i].ZLNR);
                rowtemp.CreateCell(15).SetCellValue(list[i].YJFX);
                rowtemp.CreateCell(16).SetCellValue(list[i].RCURL);
                rowtemp.CreateCell(17).SetCellValue(list[i].EMAIL);
                rowtemp.CreateCell(18).SetCellValue(list[i].PHONE);
                rowtemp.CreateCell(19).SetCellValue(list[i].ADDRESS);
                rowtemp.CreateCell(20).SetCellValue(list[i].BZ);
                rowtemp.CreateCell(21).SetCellValue(list[i].RANK.ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            string TableName ;
            if (sslb=="All")
            {
                TableName = "人才信息汇总";
            }else
            {
                TableName = sslb;
            }
            TableName = TableName + ".xls";
            return File(ms, "application/vnd.ms-excel", TableName);
        }
        public FileResult OutExcelBySSZL()//根据总领域及所属子类导出excel
        {
            var sszl = Session["SSZL"].ToString();
            var sslb = Session["SSLB"].ToString();
            decimal score = 0;
            RankDao rank = new RankDao();
            string var = Request.ToString();
            MapDao dao = new MapDao();
            IList<Data> datas = dao.getModelListBySSLBAndSSZL(sslb, sszl);
            List<DataForExcel> list = new List<DataForExcel>();

            DataForExcel rankData;
            foreach (Data data in datas)
            {
                decimal priceSocre = rank.getPriceSocre(data.PRICE);
                score = rank.getSocre(data.ZC,  data.TX, data.ZLNUMBER) + priceSocre;
                rankData = new DataForExcel();
                rankData.SSLB = data.SSLB;
                rankData.SSZL = data.SSZL;
                rankData.RCLB = data.RCLB;
                rankData.RCNAME = data.RCNAME;
                rankData.SEX = data.SEX;
                rankData.BIRTHDAY = data.BIRTHDAY;
                rankData.SZJG = data.SZJG;
                rankData.COUNTRY = data.COUNTRY;
                rankData.CITY = data.CITY;
                rankData.SF = data.SF;
                rankData.ZC = data.ZC;
                rankData.ZW = data.ZW;
                rankData.TX = data.TX;
                rankData.PRICE = data.PRICE;
                rankData.ZLNUMBER = data.ZLNUMBER;
                rankData.ZLNR = data.ZLNR;
                rankData.YJFX = data.YJFX;
                rankData.RCURL = data.RCURL;
                rankData.EMAIL = data.EMAIL;
                rankData.PHONE = data.PHONE;
                rankData.ADDRESS = data.ADDRESS;
                rankData.BZ = data.BZ;
                rankData.RANK = score;
                list.Add(rankData);
            }
            /*
             C#中list排序 ，正排序如图，使用lambda表达式，根据字段rank排序，
             * 如果需要反序，前面加一个负号
             */
            list.Sort((DataForExcel x, DataForExcel y) => { return -x.RANK.CompareTo(y.RANK); });



            //获取list数据

            IUserDao UserDao = new UserDao();
            // IList<User> list = UserDao.LoadAll();
            //创建Excel文件的对象
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            //添加一个sheet
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");

            //给sheet1添加第一行的头部标题
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
            row1.CreateCell(0).SetCellValue("所属类别");
            row1.CreateCell(1).SetCellValue("所属子类");
            row1.CreateCell(2).SetCellValue("人才类别");
            row1.CreateCell(3).SetCellValue("姓名");
            row1.CreateCell(4).SetCellValue("性别");
            row1.CreateCell(5).SetCellValue("出生日期");
            row1.CreateCell(6).SetCellValue("所在机构");
            row1.CreateCell(7).SetCellValue("国别");
            row1.CreateCell(8).SetCellValue("省");
            row1.CreateCell(9).SetCellValue("市");
            row1.CreateCell(10).SetCellValue("职称");
            row1.CreateCell(11).SetCellValue("职务");
            row1.CreateCell(12).SetCellValue("头衔");
            row1.CreateCell(13).SetCellValue("获奖情况");
            row1.CreateCell(14).SetCellValue("专利拥有量");
            row1.CreateCell(15).SetCellValue("专利内容");
            row1.CreateCell(16).SetCellValue("研究方向");
            row1.CreateCell(17).SetCellValue("人才URL");
            row1.CreateCell(18).SetCellValue("常用email");
            row1.CreateCell(19).SetCellValue("联系电话");
            row1.CreateCell(20).SetCellValue("通讯地址");
            row1.CreateCell(21).SetCellValue("备注");
            row1.CreateCell(22).SetCellValue("计分");
            //将数据逐步写入sheet1各个行
            for (int i = 0; i < list.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                rowtemp.CreateCell(0).SetCellValue(list[i].SSLB);
                rowtemp.CreateCell(1).SetCellValue(list[i].SSZL);
                rowtemp.CreateCell(2).SetCellValue(list[i].RCLB);
                rowtemp.CreateCell(3).SetCellValue(list[i].RCNAME);
                rowtemp.CreateCell(4).SetCellValue(list[i].SEX);
                rowtemp.CreateCell(5).SetCellValue(list[i].BIRTHDAY);
                rowtemp.CreateCell(6).SetCellValue(list[i].SZJG);
                rowtemp.CreateCell(7).SetCellValue(list[i].COUNTRY);
                rowtemp.CreateCell(8).SetCellValue(list[i].SF);
                rowtemp.CreateCell(9).SetCellValue(list[i].CITY);
                rowtemp.CreateCell(10).SetCellValue(list[i].ZC);
                rowtemp.CreateCell(11).SetCellValue(list[i].ZW);
                rowtemp.CreateCell(12).SetCellValue(list[i].TX);
                rowtemp.CreateCell(13).SetCellValue(list[i].PRICE);
                rowtemp.CreateCell(14).SetCellValue(list[i].ZLNUMBER);
                rowtemp.CreateCell(15).SetCellValue(list[i].ZLNR);
                rowtemp.CreateCell(16).SetCellValue(list[i].YJFX);
                rowtemp.CreateCell(17).SetCellValue(list[i].RCURL);
                rowtemp.CreateCell(18).SetCellValue(list[i].EMAIL);
                rowtemp.CreateCell(19).SetCellValue(list[i].PHONE);
                rowtemp.CreateCell(20).SetCellValue(list[i].ADDRESS);
                rowtemp.CreateCell(21).SetCellValue(list[i].BZ);
                rowtemp.CreateCell(22).SetCellValue(list[i].RANK.ToString());
            }
            // 写入到客户端 
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            string TableName = sslb + sszl + ".xls";
            return File(ms, "application/vnd.ms-excel", TableName);
        }
        public ActionResult ImportExcel(HttpPostedFileBase filebase)
        {
            HttpPostedFileBase fostFile = Request.Files["file"];
            Stream streamfile = fostFile.InputStream;
            string filename = Path.GetFileName(fostFile.FileName);
            //HSSFWorkbook hssfworkbook = new HSSFWorkbook(streamfile);  
            XSSFWorkbook hssfworkbook = new XSSFWorkbook(streamfile);
            NPOI.SS.UserModel.ISheet sheet = hssfworkbook.GetSheetAt(0);
            string a = "3D打印";
            string b = "高档数控机床";
            string c = "智能机器人";
            if (filename.IndexOf(a) > -1)
            {
                filename = a;
            }
            if (filename.IndexOf(b) > -1)
            {
                filename = b;
            }
            if (filename.IndexOf(c) > -1)
            {
                filename = c;
            }

            DataTable table = new DataTable();
            IRow headerRow = sheet.GetRow(1);//第一行为标题行  
            int cellCount = headerRow.LastCellNum;//LastCellNum = PhysicalNumberOfCells  
            int rowCount = sheet.LastRowNum;//LastRowNum = PhysicalNumberOfRows - 1  
            //handling header.  
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                if (row != null)
                {
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = GetCellValue(row.GetCell(j));
                    }
                }
                table.Rows.Add(dataRow);
            }
            for (int i = 1; i < table.Rows.Count; i++)
            {
                Data data = new Data();
                //data.SSZL = table.Rows[i][0].ToString();
                data.RCLB = table.Rows[i][0].ToString();
                data.SSLB = filename;
                // data.SSLB = table.Rows[i][0].ToString();
                // data.SSZL = table.Rows[i][0].ToString();
                data.RCNAME = table.Rows[i][1].ToString();
                data.SEX = table.Rows[i][2].ToString();
                data.BIRTHDAY = table.Rows[i][3].ToString();
                data.SZJG = table.Rows[i][4].ToString();
                data.COUNTRY = table.Rows[i][5].ToString();
                data.SF = table.Rows[i][6].ToString();
                data.CITY = table.Rows[i][7].ToString();
                data.ZC = table.Rows[i][8].ToString();
                data.ZW = table.Rows[i][9].ToString();
                data.TX = table.Rows[i][10].ToString();
                data.PRICE = table.Rows[i][11].ToString();
                if (table.Rows[i][12].ToString()=="")
                {
                    data.ZLNUMBER = 0;
                }else
                {
                    data.ZLNUMBER = Convert.ToInt32(table.Rows[i][12].ToString());
                }

                data.ZLNR = table.Rows[i][13].ToString();
                data.YJFX = table.Rows[i][14].ToString();
                data.RCURL = table.Rows[i][15].ToString();
                data.EMAIL = table.Rows[i][16].ToString();
                data.PHONE = table.Rows[i][17].ToString();
                data.ADDRESS = table.Rows[i][18].ToString();
                data.BZ = table.Rows[i][19].ToString();
                data.RCID = "a" + Guid.NewGuid().ToString("N");

                var length = data.RCNAME.Length;
                if ((data.RCNAME == "") || (data.RCNAME.Length == 0) || (data.RCNAME == null))
                {

                }
                else
                {
                    RankService service = new RankService();
                    service.saveData(data);
                    RankDao dao = new RankDao();
                    dao.saveData(data);
                }
            }

            return View("GetRank");
  
     
        }
        private static string GetCellValue(ICell cell)
        {
            if (cell == null)
                return string.Empty;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return string.Empty;
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Numeric:
                case CellType.Unknown:
                default:
                    return cell.ToString();
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Formula:
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue.ToString();
                    }
            }
        }  
	}
}


