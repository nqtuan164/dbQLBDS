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
                                tk.LoaiTaiKhoan = LoaiTaiKhoan.Admin;
                                break;
                            case 2:
                                tk.LoaiTaiKhoan = LoaiTaiKhoan.Member;
                                break;
                            case 3:
                                tk.LoaiTaiKhoan = LoaiTaiKhoan.Sales;
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

        //
        // POST/TaiKhoan/ChinhSuaTaiKhoan
        public ActionResult ChinhSuaTaiKhoan(int id) // hiển thị thông tin tài khoản
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
                    string sql = @"SELECT *
                                   FROM taikhoan tk
                                   WHERE
                                        tk.mataikhoan = " + id.ToString();
                    DataProvider dp = new DataProvider();
                    DataTable dt = new DataTable();
                    dt = dp.ExecuteQuery(sql);

                    TaiKhoan tk = new TaiKhoan();
                    if (dt.Rows.Count == 1)
                    {
                        tk.Email = (string)dt.Rows[0]["email"];
                        tk.Ten = (string)dt.Rows[0]["ten"];
                        tk.NgaySinh = (DateTime)dt.Rows[0]["ngaysinh"];
                        tk.DiaChi = (string)dt.Rows[0]["diachi"];
                        tk.DienThoai = (string)dt.Rows[0]["dienthoai"];
                        tk.NgayDangKy = (DateTime)dt.Rows[0]["ngaydangky"];

                        tk.MaLoaiTaiKhoan = (int)dt.Rows[0]["maloaitaikhoan"];
                        switch (tk.MaLoaiTaiKhoan)
                        {
                            case 1:
                                tk.LoaiTaiKhoan = LoaiTaiKhoan.Admin;
                                break;
                            case 2:
                                tk.LoaiTaiKhoan = LoaiTaiKhoan.Member;
                                break;
                            case 3:
                                tk.LoaiTaiKhoan = LoaiTaiKhoan.Sales;
                                break;
                        }

                        tk.MaTrangThai = (int)dt.Rows[0]["trangthai"];
                        switch ((int)dt.Rows[0]["trangthai"])
                        {
                            case 1:
                                tk.TrangThai = TrangThaiTaiKhoan.Active;
                                break;
                            case 0:
                                tk.TrangThai = TrangThaiTaiKhoan.Deactive;
                                break;
                        }

                        return View("~/Views/Admin/TaiKhoan/ChinhSuaTaiKhoan.cshtml", tk);
                    }
                    return Redirect("/Admin/TaiKhoan/");
                }
                catch (Exception ex)
                {
                    return Redirect("/Admin/TaiKhoan/");
                }
            }
        }

        //
        [HttpPost]
        public ActionResult ChinhSuaTaiKhoan(TaiKhoan taikhoan) //cập nhật lại tài khoản
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

                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@mataikhoan", SqlDbType.Int);
                    param[0].Value = taikhoan.MaTaiKhoan;

                    param[1] = new SqlParameter("@maloaitaikhoan", SqlDbType.Int);
                    param[1].Value = taikhoan.MaLoaiTaiKhoan;

                    param[2] = new SqlParameter("@trangthai", SqlDbType.Int);
                    param[2].Value = taikhoan.MaTrangThai;

                    dp.ExecuteProcNonQuery("sp_ChinhSuaTaiKhoan", ref param);
                    ViewBag.ErrorMessage = "Cập nhật thành công!";
                    return Redirect("/Admin/TaiKhoan/");
                }
                catch(Exception ex)
                {
                    ViewBag.ErrorMessage = "";
                    return View("~/Views/Admin/TaiKhoan/ChinhSuaTaiKhoan.cshtml", taikhoan);
                }
            }
        }

    }
}
