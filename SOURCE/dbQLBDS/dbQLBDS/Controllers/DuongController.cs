using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using dbQLBDS.Models;
using System.Data;

namespace dbQLBDS.Controllers
{
    public class DuongController : Controller
    {
        //
        // GET: /Duong/
        [ChildActionOnly]
        public ActionResult Index()
        {
            try
            {
                DataProvider dp = new DataProvider();
                string sql= @"SELECT * 
                            FROM duong
                            ORDER BY tenduong";
                DataTable dt = new DataTable();

                dt = dp.ExecuteQuery(sql);

                List<Duong> ls = new List<Duong>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Duong item = new Duong();
                        item.MaDuong = (int)dt.Rows[i]["maduong"];
                        item.TenDuong = (string)dt.Rows[i]["tenduong"];
                        item.MaQuan = (int)dt.Rows[i]["maquan"];
                        ls.Add(item);
                    }
                }
                return PartialView("~/Views/Shared/Duong.cshtml", ls);
            }
            catch (Exception ex)
            {
                return PartialView("~/Views/Shared/Duong.cshtml");
            }
            
        }

    }
}
