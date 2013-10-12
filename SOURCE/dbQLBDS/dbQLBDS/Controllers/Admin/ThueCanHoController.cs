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
            return 1;
        }
        //
        // GET: /Duong_/

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
                        item.MaCanHo = (int)dt.Rows[i]["macanho"];
                        item.TienCoc = (float)dt.Rows[i]["tiencoc"];
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

    }
}
