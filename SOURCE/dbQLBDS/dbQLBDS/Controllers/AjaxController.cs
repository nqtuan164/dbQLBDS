using dbQLBDS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbQLBDS.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/
        public void Index()
        {

        }

        [HttpPost]
        public void Index(string type, int ma)
        {
            DataProvider dp = new DataProvider();
            type = type.Trim().ToLower();

            if (type.CompareTo("loaddsquan") == 0)
            {
                //Load danh sach thanh pho
                string sql = @"SELECT * FROM quan WHERE mathanhpho = " + ma;
                DataTable dt = new DataTable();
                dt = dp.ExecuteQuery(sql);
                List<Quan> dsQuan = new List<Quan>();

                Response.Write("<option value='0'>Tất cả</option>");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Quan item = new Quan();
                        item.MaQuan = (int)dt.Rows[i]["maquan"];
                        item.TenQuan = dt.Rows[i]["tenquan"].ToString();
                        item.MaThanhPho = (int)dt.Rows[i]["mathanhpho"];

                        dsQuan.Add(item);

                        Response.Write("<option value='" + item.MaQuan.ToString() + "'>" + item.TenQuan + "</option>");
                    }
                }
            }
            else if (type.CompareTo("loaddsduong") == 0)
            {
                //Load danh sach Duong
                string sql = @"SELECT * FROM duong WHERE maquan = " + ma;
                DataTable dt = new DataTable();
                dt = dp.ExecuteQuery(sql);
                List<Duong> dsDuong = new List<Duong>();

                Response.Write("<option value='0'>Tất cả</option>");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Duong item = new Duong();
                        item.MaDuong = (int)dt.Rows[i]["maduong"];
                        item.TenDuong = dt.Rows[i]["tenduong"].ToString();
                        item.MaQuan = (int)dt.Rows[i]["maquan"];

                        dsDuong.Add(item);

                        Response.Write("<option value='" + item.MaDuong.ToString() + "'>" + item.TenDuong + "</option>");
                    }
                }
            }
        }

        
    }
}
