using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using dbQLBDS.Models;
using System.Data.SqlClient;
using System.Data;
using dbQLBDS.Controllers;

namespace QLBDS.Controllers.Admin
{
    public class TaiKhoanController : Controller
    {
        protected static int RowPerPage = 15;
        public int isLogin()
        {
            if (Session["taikhoan"] != null)
            {
                TaiKhoan tk = new TaiKhoan();
                tk = (TaiKhoan)Session["taikhoan"];
                switch (tk.MaLoaiTaiKhoan)
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
        // GET: /TaiKhoan_/

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
                    param[2].Value = DBNull.Value; // chưa biết giá trị nên cho nó bằng rỗng (= null)
                    param[2].Direction = ParameterDirection.Output;
                    DataTable dt = new DataTable();

                    dt = dp.ExecuteProcQuery("sp_DanhSachTaiKhoan", ref param);

                    List<TaiKhoan> ls = new List<TaiKhoan>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TaiKhoan tk = new TaiKhoan();

                        tk.MaTaiKhoan = (int)dt.Rows[i]["mataikhoan"];
                        tk.Email = (string)dt.Rows[i]["email"];
                        tk.MatKhau = (string)dt.Rows[i]["matkhau"];
                        switch((int)dt.Rows[i]["maloaitaikhoan"])
                        {
                            case 1:
                                tk.MaLoaiTaiKhoan = LoaiTaiKhoan.Admin;
                                break;
                            case 2:
                                tk.MaLoaiTaiKhoan = LoaiTaiKhoan.Member;
                                break;
                            case 3:
                                tk.MaLoaiTaiKhoan = LoaiTaiKhoan.Sales;
                                break;
                        }
                        
                        tk.Ten = (string)dt.Rows[i]["ten"];
                        tk.NgaySinh = (DateTime)dt.Rows[i]["ngaysinh"];
                        if (dt.Rows[i]["diachi"] != DBNull.Value) 
                        {
                            tk.DiaChi = (string)dt.Rows[i]["diachi"];
                        }
                        if (dt.Rows[i]["dienthoai"] != DBNull.Value)
                        {
                            tk.DienThoai = (string)dt.Rows[i]["dienthoai"];
                        }
                        
                        tk.NgayDangKy = (DateTime)dt.Rows[i]["ngaydangky"];

                        switch ((int)dt.Rows[i]["trangthai"])
                        {
                            case 0:
                                tk.TrangThai = TrangThaiTaiKhoan.Deactive;
                                break;
                            case 1:
                                tk.TrangThai = TrangThaiTaiKhoan.Active;
                                break;
                        }

                        ls.Add(tk);
                    }
                    ViewBag.RowPerPage = RowPerPage;
                    ViewBag.Page = page;
                    ViewBag.Count = (int)param[2].Value;

                    return View("~/Views/Admin/TaiKhoan/Index.cshtml", ls);

                }
                catch(Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return null;
                }

            }
            
        }

    }
}
