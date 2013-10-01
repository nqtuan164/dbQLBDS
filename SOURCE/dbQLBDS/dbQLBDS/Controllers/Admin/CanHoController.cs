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
    public class CanHoController : Controller
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
        // GET: /CanHo/

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
                    param[2].Value = DBNull.Value;
                    param[2].Direction = ParameterDirection.Output;
                    DataTable dt = new DataTable();

                    dt = dp.ExecuteProcQuery("sp_DanhSachCanHo", ref param);

                    List<CanHo> ls = new List<CanHo>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CanHo item = new CanHo();

                        item.MaCanHo = (int)dt.Rows[i]["macanho"];
                        item.TenCanHo = (string)dt.Rows[i]["tencanho"];
                        item.MaDuong = (int)dt.Rows[i]["maduong"];
                        item.DiaChi = (string)dt.Rows[i]["diachi"];

                        if (dt.Rows[i]["mieuta"] != DBNull.Value)
                        {
                            item.MieuTa = (string)dt.Rows[i]["mieuta"];
                        }

                        item.ToaDo = (string)dt.Rows[i]["toado"];
                        item.GiaThue = (double)dt.Rows[i]["giathue"];
                        item.DienTich = (double)dt.Rows[i]["dientich"];

                        switch ((int)dt.Rows[i]["matrangthaicanho"])
                        {
                            case 1:
                                item.MaTrangThaiCanHo = TrangThaiCanHo.Da_Duoc_Thue;
                                break;
                            case 2:
                                item.MaTrangThaiCanHo = TrangThaiCanHo.Chua_Duoc_Thue;
                                break;
                            case 3:
                                item.MaTrangThaiCanHo = TrangThaiCanHo.Dang_Xay_Dung;
                                break;
                        }

                        item.NgayDang = (DateTime)dt.Rows[i]["ngaydang"];
                        item.NguoiDang = (int)dt.Rows[i]["nguoidang"];

                        if (dt.Rows[i]["ghichu"] != DBNull.Value)
                        {
                            item.GhiChu = (string)dt.Rows[i]["ghichu"];
                        }
                        
                        item.KichHoat = (int)dt.Rows[i]["kichhoat"];

                        ls.Add(item);
                    }

                    ViewBag.RowPerPage = RowPerPage;
                    ViewBag.Page = page;
                    //Console.Write(param[3].Value.ToString());
                    ViewBag.Count = (int)param[2].Value;

                    return View("~/Views/Admin/CanHo/Index.cshtml", ls);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return null;
                }
                
            }
            
        }

        //
        // POST: /CanHo/TaoCanHo
        public ActionResult TaoCanHo()
        {
            return View("~/Views/Admin/CanHo/TaoCanHo.cshtml");
        }

        //
        // POST: /CanHo/ChinhSuaCanHo
        public ActionResult ChinhSuaCanHo(int id)
        {
            return View("~/Views/Admin/CanHo/TaoCanHo.cshtml");
        }

    }
}
