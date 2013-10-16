using dbQLBDS.Controllers;
using dbQLBDS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBDS.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            //Load danh sach thanh pho
            DataProvider dp = new DataProvider();
            string sql = @"SELECT TOP 8 ch.*, d.tenduong, q.tenquan, tp.tenthanhpho
                        FROM canho ch, duong d, quan q, thanhpho tp
                        WHERE ch.kichhoat = 1 AND
	                        ch.matrangthaicanho = 2 AND
	                        ch.maduong = d.maduong AND
	                        d.maquan = q.maquan AND
	                        q.mathanhpho = tp.mathanhpho
                        ORDER BY ch.ngaydang DESC
                        ";
            DataTable dt = new DataTable();
            dt = dp.ExecuteQuery(sql);

            List<CanHo> dsCanHo = new List<CanHo>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CanHo item = new CanHo();
                    item.MaCanHo = (int)dt.Rows[i]["macanho"];
                    item.TenCanHo = dt.Rows[i]["tencanho"].ToString();
                    item.MaDuong = (int)dt.Rows[i]["maduong"];
                    item.DiaChi = dt.Rows[i]["diachi"].ToString() + " " +
                                    dt.Rows[i]["tenduong"].ToString() + ", " +
                                    dt.Rows[i]["tenquan"].ToString() + ", " +
                                    dt.Rows[i]["tenthanhpho"].ToString();
                    item.MieuTa = dt.Rows[i]["mieuta"].ToString();
                    item.ToaDo = dt.Rows[i]["toado"].ToString();
                    item.GiaThue = (double)dt.Rows[i]["giathue"];
                    item.DienTich = (double)dt.Rows[i]["dientich"];
                    item.MaTrangThaiCanHo = (int)dt.Rows[i]["matrangthaicanho"];
                    item.TrangThaiCanHo = (TrangThaiCanHo)dt.Rows[i]["matrangthaicanho"];
                    item.NgayDang = DateTime.Parse(dt.Rows[i]["ngaydang"].ToString());
                    item.NguoiDang = (int)dt.Rows[i]["nguoidang"];
                    item.GhiChu = dt.Rows[i]["ghichu"].ToString();
                    item.KichHoat = (int)dt.Rows[i]["kichhoat"];

                    dsCanHo.Add(item);
                }
            }

            return View("~/Views/Index.cshtml", dsCanHo);
            //return Request.Url.Host;
        }

    }
}
