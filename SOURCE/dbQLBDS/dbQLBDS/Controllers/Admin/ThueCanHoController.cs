using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Sql;
using System.Data.SqlClient;
using dbQLBDS.Models;
using dbQLBDS.Controllers;
using System.Data;
using System.Web.Helpers;

namespace QLBDS.Controllers.Admin
{
    public class ThueCanHoController : Controller
    {
        protected static int RowPerPage = 15;
        public int isLogin()
        {
            if (Session["taikhoan"] != null)
            {
                TaiKhoan tk = new TaiKhoan();
                tk = (TaiKhoan)Session["taikhoan"];
                switch (tk.LoaiTaiKhoan)
                {
                    case LoaiTaiKhoan.Admin:
                        return 1;
                    case LoaiTaiKhoan.Member:
                        return 2;
                    case LoaiTaiKhoan.Sales:
                        return 3;
                };
            }
            return -1;
        }
        //
        // GET: /ThueCanHo/

        public ActionResult Index()
        {
            if (isLogin() == -1)
            {
                return Redirect("/DangNhap");
            }
            else if (isLogin() == 2)
            {
                return Redirect("/");
            }
            else
            {
                //*/
                try
                {
                    DataProvider dp = new DataProvider();

                    int page = 1;
                    if (Request.QueryString["page"] != null)
                    {
                        page = int.Parse(Request.QueryString["page"]);
                    }

                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@page", SqlDbType.Int);
                    param[0].Value = page;

                    param[1] = new SqlParameter("@pagesize", SqlDbType.Int);
                    param[1].Value = RowPerPage;

                    param[2] = new SqlParameter("@count", SqlDbType.Int);
                    param[2].Value = DBNull.Value; //Chua biet gia tri
                    param[2].Direction = ParameterDirection.Output;
                    DataTable dt = new DataTable();

                    dt = dp.ExecuteProcQuery("sp_DanhSachThueCanHo", ref param);

                    List<ThueCanHo> ls = new List<ThueCanHo>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ThueCanHo item = new ThueCanHo();

                        item.MaThueCanHo = (int)dt.Rows[i]["mathuecanho"];
                        item.MaTaiKhoan = (int)dt.Rows[i]["mataikhoan"];
                        item.TenTaiKhoan = (string)dt.Rows[i]["ten"];
                        item.MaCanHo = (int)dt.Rows[i]["macanho"];
                        item.TenCanHo = (string)dt.Rows[i]["tencanho"];
                        item.TienCoc = (double)dt.Rows[i]["tiencoc"];
                        item.ThoiGianThue = (DateTime)dt.Rows[i]["thoigianthue"];
                        item.ThoiGianKetThuc = (DateTime)dt.Rows[i]["thoigianketthuc"];
                        item.ThoiGianGiaoDich = (DateTime)dt.Rows[i]["thoigiangiaodich"];

                        if (dt.Rows[i]["dienthoai"] != DBNull.Value)
                        {
                            item.DienThoai = (string)dt.Rows[i]["dienthoai"];
                        }
                        if (dt.Rows[i]["diachi"] != DBNull.Value)
                        {
                            item.DiaChi = (string)dt.Rows[i]["diachi"];
                        }
                        if (dt.Rows[i]["ghichu"] != DBNull.Value)
                        {
                            item.GhiChu = (string)dt.Rows[i]["ghichu"];
                        }
                        item.KichHoat = (int)dt.Rows[i]["kichhoat"];

                        ls.Add(item);
                    }

                    ViewBag.RowPerPage = RowPerPage;
                    ViewBag.Page = page;
                    ViewBag.Count = (int)param[2].Value;

                    return View("~/Views/Admin/ThueCanHo/Index.cshtml", ls);

                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return null;
                }
                //*/
            }
        }

        public ActionResult ChiTietThueCanHo(int id)
        {
            if (isLogin() == -1)
            {
                return Redirect("/DangNhap");
            }
            else if (isLogin() == 2)
            {
                return Redirect("/");
            }
            else
            {
                try
                {
                    DataProvider dp = new DataProvider();

                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@mathuecanho", SqlDbType.Int);
                    param[0].Value = id;

                    DataTable dt = new DataTable();
                    dt = dp.ExecuteProcQuery("sp_ChiTietThueCanHo", ref param);

                    ThueCanHo item = new ThueCanHo();
                    if (dt.Rows.Count > 0)
                    {
                        item.MaThueCanHo = (int)dt.Rows[0]["mathuecanho"];
                        item.MaTaiKhoan = (int)dt.Rows[0]["mataikhoan"];
                        item.TenTaiKhoan = (string)dt.Rows[0]["ten"];
                        item.MaCanHo = (int)dt.Rows[0]["macanho"];
                        item.TenCanHo = (string)dt.Rows[0]["tencanho"];
                        item.TienCoc = (double)dt.Rows[0]["tiencoc"];
                        item.ThoiGianThue = (DateTime)dt.Rows[0]["thoigianthue"];
                        item.ThoiGianKetThuc = (DateTime)dt.Rows[0]["thoigianketthuc"];
                        item.ThoiGianGiaoDich = (DateTime)dt.Rows[0]["thoigiangiaodich"];

                        if (dt.Rows[0]["dienthoai"] != DBNull.Value)
                        {
                            item.DienThoai = (string)dt.Rows[0]["dienthoai"];
                        }
                        if (dt.Rows[0]["diachi"] != DBNull.Value)
                        {
                            item.DiaChi = (string)dt.Rows[0]["diachi"];
                        }
                        if (dt.Rows[0]["ghichu"] != DBNull.Value)
                        {
                            item.GhiChu = (string)dt.Rows[0]["ghichu"];
                        }
                        item.KichHoat = (int)dt.Rows[0]["kichhoat"];
                    }

                    GiaoDich gd = GiaoDichController.DanhSachGiaoDichThueCanHo(item.MaThueCanHo);

                    if (gd != null)
                    {
                        ViewBag.DanhSachGiaoDich = gd;
                    }

                    return View("~/Views/Admin/ThueCanHo/ChiTietThueCanHo.cshtml", item);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return Redirect("/Admin/ThueCanHo/");
                }
            }
        }

        [HttpPost, ActionName("ChiTietThueCanHo")]
        public ActionResult NhanGiaoDichThueCanHo(ThueCanHo thuecanho)
        {
            if (isLogin() == -1)
            {
                return Redirect("/DangNhap");
            }
            else if (isLogin() == 2)
            {
                return Redirect("/");
            }
            else
            {
                try
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk = (TaiKhoan)Session["taikhoan"];

                    DataProvider dp = new DataProvider();

                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@mataikhoan", SqlDbType.Int);
                    param[0].Value = tk.MaTaiKhoan;

                    param[1] = new SqlParameter("@mathuecanho", SqlDbType.Int);
                    param[1].Value = thuecanho.MaThueCanHo;

                    dp.ExecuteProcNonQuery("sp_NhanGiaoDich", ref param);
                    return Redirect("/Admin/ThueCanHo/ChiTietThueCanHo/" + thuecanho.MaThueCanHo.ToString());
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return Redirect("/Admin/ThueCanHo/");
                }
            }
        }

    }
}
