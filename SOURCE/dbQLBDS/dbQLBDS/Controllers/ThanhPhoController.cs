using dbQLBDS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbQLBDS.Controllers
{
    public class ThanhPhoController : Controller
    {
        //
        // GET: /ThanhPho/

        [ChildActionOnly]
        public ActionResult Index()
        {
            try
            {
                DataProvider dp = new DataProvider();
                string sql = @"SELECT * 
                            FROM thanhpho
                            ORDER BY tenthanhpho";
                DataTable dt = new DataTable();

                dt = dp.ExecuteQuery(sql);

                List<ThanhPho> ls = new List<ThanhPho>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ThanhPho item = new ThanhPho();
                        item.MaThanhPho = (int)dt.Rows[i]["mathanhpho"];
                        item.TenThanhPho = (string)dt.Rows[i]["tenthanhpho"];
                        ls.Add(item);
                    }
                }

                ViewBag.MaThanhPho = new SelectList(ls, "mathanhpho", "tenthanhpho", 1);

                return PartialView("~/Views/Shared/ThanhPho.cshtml", ls);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ThanhPho.cshtml");
            }

        }

        public static List<ThanhPho> ListThanhPho()
        {
            List<ThanhPho> ls = new List<ThanhPho>();
            try
            {
                DataProvider dp = new DataProvider();
                string sql = @"SELECT * 
                            FROM thanhpho
                            ORDER BY tenthanhpho";
                DataTable dt = new DataTable();

                dt = dp.ExecuteQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ThanhPho item = new ThanhPho();
                        item.MaThanhPho = (int)dt.Rows[i]["mathanhpho"];
                        item.TenThanhPho = (string)dt.Rows[i]["tenthanhpho"];
                        ls.Add(item);
                    }
                }
                return ls;
            }
            catch (Exception ex)
            {
                return ls;
            }
        }

    }
}
