using dbQLBDS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbQLBDS.Controllers
{
    public class DatThueCanHoController : Controller
    {
        public TaiKhoan isLogin()
        {
            if (Session["taikhoan"] != null)
            {
                TaiKhoan tk = new TaiKhoan();
                tk = (TaiKhoan)Session["taikhoan"];
                return tk;
            }
            return null;
        }

        //
        // GET: /DatThueCanHo/

        public ActionResult Index()
        {
            TaiKhoan tk = isLogin();
            if (tk == null)
            {
                return Redirect("/DangNhap");
            }

            int canHoID = 0;
            CanHo ch = new CanHo();

            if (!Int32.TryParse(Request.Params["id"], out canHoID))
            {
                ch.MaTrangThaiCanHo = -999;
            }
            else
            {
                DataProvider dp = new DataProvider();

                //Load danh sach thanh pho
                string sql = @"SELECT ch.*, d.tenduong, q.tenquan, tp.tenthanhpho
                                FROM canho ch, duong d, quan q, thanhpho tp
                                WHERE ch.kichhoat = 1 AND
                                    ch.matrangthaicanho = 2 AND
                                    ch.maduong = d.maduong AND
                                    d.maquan = q.maquan AND
                                    q.mathanhpho = tp.mathanhpho AND
                                    ch.macanho = " + canHoID.ToString() + @"
                                ";
                DataTable dt = new DataTable();
                dt = dp.ExecuteQuery(sql);

                if (dt.Rows.Count > 0)
                {
                    ch.MaCanHo = (int)dt.Rows[0]["macanho"];
                    ch.TenCanHo = dt.Rows[0]["tencanho"].ToString();
                    ch.MaDuong = (int)dt.Rows[0]["maduong"];
                    ch.DiaChi = dt.Rows[0]["diachi"].ToString() + " " +
                                    dt.Rows[0]["tenduong"].ToString() + ", " +
                                    dt.Rows[0]["tenquan"].ToString() + ", " +
                                    dt.Rows[0]["tenthanhpho"].ToString();
                    ch.MieuTa = dt.Rows[0]["mieuta"].ToString();
                    ch.ToaDo = dt.Rows[0]["toado"].ToString();
                    ch.GiaThue = (double)dt.Rows[0]["giathue"];
                    ch.DienTich = (double)dt.Rows[0]["dientich"];
                    ch.MaTrangThaiCanHo = (int)dt.Rows[0]["matrangthaicanho"];
                    ch.TrangThaiCanHo = (TrangThaiCanHo)dt.Rows[0]["matrangthaicanho"];
                    ch.NgayDang = DateTime.Parse(dt.Rows[0]["ngaydang"].ToString());
                    ch.NguoiDang = (int)dt.Rows[0]["nguoidang"];
                    ch.GhiChu = dt.Rows[0]["ghichu"].ToString();
                    ch.KichHoat = (int)dt.Rows[0]["kichhoat"];
                }
                else
                {
                    ch.MaTrangThaiCanHo = -999;
                }
            }

            ViewBag.taiKhoan = tk;

            return View("~/Views/Shared/DatThueCanHo.cshtml", ch);
        }

    }
}
