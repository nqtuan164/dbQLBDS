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
                                item.TrangThaiCanHo = TrangThaiCanHo.Da_Duoc_Thue;
                                break;
                            case 2:
                                item.TrangThaiCanHo = TrangThaiCanHo.Chua_Duoc_Thue;
                                break;
                            case 3:
                                item.TrangThaiCanHo = TrangThaiCanHo.Dang_Xay_Dung;
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
                List<ThanhPho> lsThanhPho = new List<ThanhPho>();
                lsThanhPho = ThanhPhoController.ListThanhPho();
                ViewBag.MaThanhPho = new SelectList(lsThanhPho, "mathanhpho", "tenthanhpho");

                List<Quan> lsQuan = new List<Quan>();
                lsQuan = QuanController.ListQuan();
                ViewBag.MaQuan = new SelectList(lsQuan, "maquan", "tenquan");

                List<Duong> lsDuong = new List<Duong>();
                lsDuong = DuongController.ListDuong();
                ViewBag.MaDuong = new SelectList(lsDuong, "maduong", "tenduong");
            }
            return View("~/Views/Admin/CanHo/TaoCanHo.cshtml");
        }

        [HttpPost]
        public ActionResult TaoCanHo(CanHo canho)
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

                    canho.NguoiDang = tk.MaTaiKhoan;
                    canho.NgayDang = DateTime.Now;

                    SqlParameter[] param = new SqlParameter[10];
                    param[0] = new SqlParameter("@tencanho", SqlDbType.NVarChar);
                    param[0].Value = canho.TenCanHo;

                    param[1] = new SqlParameter("@maduong", SqlDbType.Int);
                    param[1].Value = canho.MaDuong;

                    param[2] = new SqlParameter("@diachi", SqlDbType.NVarChar);
                    param[2].Value = canho.DiaChi;

                    param[3] = new SqlParameter("@mieuta", SqlDbType.NVarChar);
                    param[3].Value = canho.MieuTa;

                    param[4] = new SqlParameter("@toado", SqlDbType.NVarChar);
                    param[4].Value = canho.ToaDo;

                    param[5] = new SqlParameter("@giathue", SqlDbType.Float);
                    param[5].Value = canho.GiaThue;

                    param[6] = new SqlParameter("@dientich", SqlDbType.Float);
                    param[6].Value = canho.DienTich;

                    param[7] = new SqlParameter("@matrangthaicanho", SqlDbType.Int);
                    param[7].Value = canho.MaTrangThaiCanHo;

                    param[8] = new SqlParameter("@ngaydang", SqlDbType.DateTime);
                    param[8].Value = canho.NgayDang;

                    param[9] = new SqlParameter("@nguoidang", SqlDbType.Int);
                    param[9].Value = canho.NguoiDang;

                    DataProvider dp = new DataProvider();
                    dp.ExecuteProcNonQuery("sp_TaoCanHo", ref param);

                    ViewBag.ErrorMessage = "Đăng tin căn hộ thành công";
                    return Redirect("/Admin/CanHo/");
                }
                catch (Exception ex)
                {
                    List<ThanhPho> lsThanhPho = new List<ThanhPho>();
                    lsThanhPho = ThanhPhoController.ListThanhPho();
                    ViewBag.MaThanhPho = new SelectList(lsThanhPho, "mathanhpho", "tenthanhpho");

                    List<Quan> lsQuan = new List<Quan>();
                    lsQuan = QuanController.ListQuan();
                    ViewBag.MaQuan = new SelectList(lsQuan, "maquan", "tenquan");

                    List<Duong> lsDuong = new List<Duong>();
                    lsDuong = DuongController.ListDuong();
                    ViewBag.MaDuong = new SelectList(lsDuong, "maduong", "tenduong");

                    ViewBag.ErrorMessage = "Khởi tạo không thành công";
                    return View("~/Views/Admin/CanHo/TaoCanHo.cshtml");
                }
                
            }
            
        }


        //
        // POST: /CanHo/ChinhSuaCanHo
        public ActionResult ChinhSuaCanHo(int id)
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
                    string sql = @"SELECT * , tk.ten as tennguoidang
                                   FROM canho ch, taikhoan tk 
                                   WHERE 
                                        tk.mataikhoan = ch.nguoidang AND 
                                        ch.macanho = " + id.ToString() + @" AND 
                                        ch.kichhoat = 1 ";

                    DataProvider dp = new DataProvider();
                    DataTable dt = new DataTable();
                    dt = dp.ExecuteQuery(sql);

                    CanHo item = new CanHo();
                    if (dt.Rows.Count == 1)
                    {
                        item.MaCanHo = (int)dt.Rows[0]["macanho"];
                        item.TenCanHo = (string)dt.Rows[0]["tencanho"];
                        item.MaDuong = (int)dt.Rows[0]["maduong"];
                        item.DiaChi = (string)dt.Rows[0]["diachi"];

                        if (dt.Rows[0]["mieuta"] != DBNull.Value)
                        {
                            item.MieuTa = (string)dt.Rows[0]["mieuta"];
                        }

                        item.ToaDo = (string)dt.Rows[0]["toado"];
                        item.GiaThue = (double)dt.Rows[0]["giathue"];
                        item.DienTich = (double)dt.Rows[0]["dientich"];
                        item.MaTrangThaiCanHo = (int)dt.Rows[0]["matrangthaicanho"];

                        switch ((int)dt.Rows[0]["matrangthaicanho"])
                        {
                            case 1:
                                item.TrangThaiCanHo = TrangThaiCanHo.Da_Duoc_Thue;
                                break;
                            case 2:
                                item.TrangThaiCanHo = TrangThaiCanHo.Chua_Duoc_Thue;
                                break;
                            case 3:
                                item.TrangThaiCanHo = TrangThaiCanHo.Dang_Xay_Dung;
                                break;
                        }

                        item.NgayDang = (DateTime)dt.Rows[0]["ngaydang"];
                        item.NguoiDang = (int)dt.Rows[0]["nguoidang"];
                        item.TenNguoiDang = (string)dt.Rows[0]["tennguoidang"];

                        if (dt.Rows[0]["ghichu"] != DBNull.Value)
                        {
                            item.GhiChu = (string)dt.Rows[0]["ghichu"];
                        }

                        item.KichHoat = (int)dt.Rows[0]["kichhoat"];

                        List<ThanhPho> lsThanhPho = new List<ThanhPho>();
                        lsThanhPho = ThanhPhoController.ListThanhPho();
                        ViewBag.MaThanhPho = new SelectList(lsThanhPho, "mathanhpho", "tenthanhpho");

                        List<Quan> lsQuan = new List<Quan>();
                        lsQuan = QuanController.ListQuan();
                        ViewBag.MaQuan = new SelectList(lsQuan, "maquan", "tenquan");

                        List<Duong> lsDuong = new List<Duong>();
                        lsDuong = DuongController.ListDuong();
                        ViewBag.MaDuong = new SelectList(lsDuong, "maduong", "tenduong", item.MaDuong);

                        return View("~/Views/Admin/CanHo/ChinhSuaCanHo.cshtml", item);
                    }
                    return Redirect("/Admin/CanHo/");
                }
                catch (Exception ex)
                {
                    return Redirect("/Admin/CanHo/");
                }
                //*/
            }
            
        }

        [HttpPost]
        public ActionResult ChinhSuaCanHo(CanHo canho)
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

                    SqlParameter[] param = new SqlParameter[9];
                    param[0] = new SqlParameter("@macanho", SqlDbType.Int);
                    param[0].Value = canho.MaCanHo;

                    param[1] = new SqlParameter("@tencanho", SqlDbType.NVarChar);
                    param[1].Value = canho.TenCanHo;

                    param[2] = new SqlParameter("@maduong", SqlDbType.Int);
                    param[2].Value = canho.MaDuong;

                    param[3] = new SqlParameter("@diachi", SqlDbType.NVarChar);
                    param[3].Value = canho.DiaChi;

                    param[4] = new SqlParameter("@mieuta", SqlDbType.NVarChar);
                    param[4].Value = canho.MieuTa;

                    param[5] = new SqlParameter("@toado", SqlDbType.NVarChar);
                    param[5].Value = canho.ToaDo;

                    param[6] = new SqlParameter("@giathue", SqlDbType.Float);
                    param[6].Value = canho.GiaThue;

                    param[7] = new SqlParameter("@dientich", SqlDbType.Float);
                    param[7].Value = canho.DienTich;

                    param[8] = new SqlParameter("@matrangthaicanho", SqlDbType.Int);
                    param[8].Value = canho.MaTrangThaiCanHo;

                    dp.ExecuteProcNonQuery("sp_ChinhSuaCanHo", ref param);

                    ViewBag.ErrorMessage = "Cập nhật thành công!";
                    return Redirect("/Admin/CanHo/");

                }
                catch (Exception ex)
                {
                    List<ThanhPho> lsThanhPho = new List<ThanhPho>();
                    lsThanhPho = ThanhPhoController.ListThanhPho();
                    ViewBag.MaThanhPho = new SelectList(lsThanhPho, "mathanhpho", "tenthanhpho");

                    List<Quan> lsQuan = new List<Quan>();
                    lsQuan = QuanController.ListQuan();
                    ViewBag.MaQuan = new SelectList(lsQuan, "maquan", "tenquan");

                    List<Duong> lsDuong = new List<Duong>();
                    lsDuong = DuongController.ListDuong();
                    ViewBag.MaDuong = new SelectList(lsDuong, "maduong", "tenduong", canho.MaDuong);
                    ViewBag.ErrorMessage = "";
                    return View("~/Views/Admin/CanHo/ChinhSuaCanHo.cshtml", canho);
                }
                //*/
            }

            
        }

        public ActionResult XoaCanHo(int id)
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
                    string sql = "SELECT * FROM canho WHERE macanho = " + id.ToString();

                    DataTable dt = new DataTable();
                    dt = dp.ExecuteQuery(sql);

                    CanHo item = new CanHo();
                    if (dt.Rows.Count == 1)
                    {
                        item.MaCanHo = (int)dt.Rows[0]["macanho"];
                        item.TenCanHo = (string)dt.Rows[0]["tencanho"];
                        item.MaDuong = (int)dt.Rows[0]["maduong"];
                        item.DiaChi = (string)dt.Rows[0]["diachi"];

                        if (dt.Rows[0]["mieuta"] != DBNull.Value)
                        {
                            item.MieuTa = (string)dt.Rows[0]["mieuta"];
                        }

                        item.ToaDo = (string)dt.Rows[0]["toado"];
                        item.GiaThue = (double)dt.Rows[0]["giathue"];
                        item.DienTich = (double)dt.Rows[0]["dientich"];
                        item.MaTrangThaiCanHo = (int)dt.Rows[0]["matrangthaicanho"];

                        switch ((int)dt.Rows[0]["matrangthaicanho"])
                        {
                            case 1:
                                item.TrangThaiCanHo = TrangThaiCanHo.Da_Duoc_Thue;
                                break;
                            case 2:
                                item.TrangThaiCanHo = TrangThaiCanHo.Chua_Duoc_Thue;
                                break;
                            case 3:
                                item.TrangThaiCanHo = TrangThaiCanHo.Dang_Xay_Dung;
                                break;
                        }

                        item.NgayDang = (DateTime)dt.Rows[0]["ngaydang"];
                        item.NguoiDang = (int)dt.Rows[0]["nguoidang"];

                        if (dt.Rows[0]["ghichu"] != DBNull.Value)
                        {
                            item.GhiChu = (string)dt.Rows[0]["ghichu"];
                        }

                        item.KichHoat = (int)dt.Rows[0]["kichhoat"];


                        return View("~/Views/Admin/CanHo/XoaCanHo.cshtml", item);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Không tìm thấy căn hộ";
                        return Redirect("/Admin/CanHo/");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return Redirect("/Admin/CanHo/");
                }
            }
        }

        [HttpPost, ActionName("XoaCanHo")]
        public ActionResult XacNhanXoaCanHo(int id)
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
                    param[0] = new SqlParameter("@macanho", SqlDbType.Int);
                    param[0].Value = id;

                    dp.ExecuteProcNonQuery("sp_XoaCanHo", ref param);
                    ViewBag.ErrorMessage = "";
                    return Redirect("/Admin/CanHo/");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return Redirect("/Admin/CanHo/");
                }
            }
        }


    }
}
