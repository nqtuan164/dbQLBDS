using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using dbQLBDS.Models;
using dbQLBDS.Controllers;
using System.Data;
using System.Data.SqlClient;

namespace QLBDS.Controllers.Admin
{
    public class GiaoDichController : Controller
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
        // GET: /NhanGiaoDich_/

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
                    TaiKhoan tk = new TaiKhoan();
                    tk = (TaiKhoan)Session["taikhoan"];

                    DataProvider dp = new DataProvider();

                    int page = 1;
                    if (Request.QueryString["page"] != null)
                    {
                        page = int.Parse(Request.QueryString["page"]);
                    }

                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@mataikhoan", SqlDbType.Int);
                    param[0].Value = tk.MaTaiKhoan;

                    param[1] = new SqlParameter("@page", SqlDbType.Int);
                    param[1].Value = page;

                    param[2] = new SqlParameter("@pagesize", SqlDbType.Int);
                    param[2].Value = RowPerPage;

                    param[3] = new SqlParameter("@count", SqlDbType.Int);
                    param[3].Value = DBNull.Value; //Chua biet gia tri
                    param[3].Direction = ParameterDirection.Output;
                    DataTable dt = new DataTable();

                    dt = dp.ExecuteProcQuery("sp_DanhSachGiaoDich", ref param);

                    List<GiaoDich> ls = new List<GiaoDich>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        GiaoDich item = new GiaoDich();

                        item.MaGiaoDich = (int)dt.Rows[i]["magiaodich"];
                        item.MaTaiKhoan = (int)dt.Rows[i]["mataikhoan"];
                        item.TenTaiKhoan = (String)dt.Rows[i]["ten"];
                        item.MaThueCanHo = (int)dt.Rows[i]["mathuecanho"];
                        item.MaTrangThaiGiaoDich = (int)dt.Rows[i]["matrangthaigiaodich"];
                        switch (item.MaTrangThaiGiaoDich)
                        {
                            case 1:
                                item.TrangThaiGiaoDich = TrangThaiGiaoDich.Cho_Xac_Nhan;
                                break;
                            case 2:
                                item.TrangThaiGiaoDich = TrangThaiGiaoDich.Dang_Giao_Dich;
                                break;
                            case 3:
                                item.TrangThaiGiaoDich = TrangThaiGiaoDich.Da_Giao_Dich;
                                break;
                            case 4:
                                item.TrangThaiGiaoDich = TrangThaiGiaoDich.Thanh_Toan_Hoan_Tat;
                                break;
                            case 5:
                                item.TrangThaiGiaoDich = TrangThaiGiaoDich.Giao_Dich_Huy_Bo;
                                break;
                        }

                        ls.Add(item);
                    }

                    ViewBag.RowPerPage = RowPerPage;
                    ViewBag.Page = page;
                    //Console.Write(param[3].Value.ToString());
                    ViewBag.Count = (int)param[3].Value;

                    return View("~/Views/Admin/GiaoDich/Index.cshtml", ls);

                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return Redirect("/Admin/");
                }
                //*/
            }

        }

        public static GiaoDich DanhSachGiaoDichThueCanHo(int mathuecanho)
        {
            try
            {
                GiaoDich item = new GiaoDich();

                DataProvider dp = new DataProvider();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@mathuecanho", SqlDbType.Int);
                param[0].Value = mathuecanho;

                DataTable dt = new DataTable();
                dt = dp.ExecuteProcQuery("sp_DanhSachNhanGiaoDichThueCanHo", ref param);

                if (dt.Rows.Count > 0)
                {
                    item.MaGiaoDich = (int)dt.Rows[0]["magiaodich"];
                    item.MaTaiKhoan = (int)dt.Rows[0]["mataikhoan"];
                    item.TenTaiKhoan = (String)dt.Rows[0]["ten"];
                    item.MaLoaiTaiKhoan = (int)dt.Rows[0]["maloaitaikhoan"];
                    item.MaThueCanHo = (int)dt.Rows[0]["mathuecanho"];
                    item.MaTrangThaiGiaoDich = (int)dt.Rows[0]["matrangthaigiaodich"];
                    switch (item.MaTrangThaiGiaoDich)
                    {
                        case 1:
                            item.TrangThaiGiaoDich = TrangThaiGiaoDich.Cho_Xac_Nhan;
                            break;
                        case 2:
                            item.TrangThaiGiaoDich = TrangThaiGiaoDich.Dang_Giao_Dich;
                            break;
                        case 3:
                            item.TrangThaiGiaoDich = TrangThaiGiaoDich.Da_Giao_Dich;
                            break;
                        case 4:
                            item.TrangThaiGiaoDich = TrangThaiGiaoDich.Thanh_Toan_Hoan_Tat;
                            break;
                        case 5:
                            item.TrangThaiGiaoDich = TrangThaiGiaoDich.Giao_Dich_Huy_Bo;
                            break;
                    }
                    return item;
                }
                else return null;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
