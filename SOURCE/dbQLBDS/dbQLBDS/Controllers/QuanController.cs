﻿using dbQLBDS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbQLBDS.Controllers
{
    public class QuanController : Controller
    {
        
        //
        // GET: /Quan/
        [ChildActionOnly]
        public ActionResult Index()
        {
            try
            {
                DataProvider dp = new DataProvider();
                string sql = @"SELECT * 
                            FROM quan
                            ORDER BY maquan";
                DataTable dt = new DataTable();

                dt = dp.ExecuteQuery(sql);

                List<Quan> ls = new List<Quan>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Quan item = new Quan();
                        item.MaQuan = (int)dt.Rows[i]["maquan"];
                        item.TenQuan = (string)dt.Rows[i]["tenquan"];
                        item.MaThanhPho = (int)dt.Rows[i]["mathanhpho"];
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

        public static List<Quan> ListQuan()
        {
            List<Quan> ls = new List<Quan>();
            try
            {
                DataProvider dp = new DataProvider();
                string sql = @"SELECT * 
                            FROM quan
                            ORDER BY maquan";
                DataTable dt = new DataTable();

                dt = dp.ExecuteQuery(sql);

                
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Quan item = new Quan();
                        item.MaQuan = (int)dt.Rows[i]["maquan"];
                        item.TenQuan = (string)dt.Rows[i]["tenquan"];
                        item.MaThanhPho = (int)dt.Rows[i]["mathanhpho"];
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

        [HttpPost]
        public ActionResult ListQuan(int mathanhpho)
        {
            List<Quan> ls = new List<Quan>();
            try
            {
                DataProvider dp = new DataProvider();
                string sql = @"SELECT * 
                            FROM quan
                            WHERE mathanhpho = " + mathanhpho.ToString() + @"
                            ORDER BY maquan";
                DataTable dt = new DataTable();

                dt = dp.ExecuteQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Quan item = new Quan();
                        item.MaQuan = (int)dt.Rows[i]["maquan"];
                        item.TenQuan = (string)dt.Rows[i]["tenquan"];
                        item.MaThanhPho = (int)dt.Rows[i]["mathanhpho"];
                        ls.Add(item);
                    }
                }
                return Json(ls);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
