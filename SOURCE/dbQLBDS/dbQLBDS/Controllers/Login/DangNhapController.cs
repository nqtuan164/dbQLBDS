using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using dbQLBDS.Models;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace dbQLBDS.Controllers.Login
{
    public class DangNhapController : Controller
    {
        //
        // GET: /DangNhap/
        public ActionResult Index()
        {
            return View("~/Views/Login/DangNhap.cshtml");
        }

        [HttpPost]
        public ActionResult Index(TaiKhoan taikhoan)
        {
            try
            {
                if (taikhoan.Email != null && taikhoan.MatKhau != null)
                {
                    DataProvider dp = new DataProvider();

                    using (MD5 md5hash = MD5.Create())
                    {
                        string hash = GetMd5Hash(md5hash, taikhoan.MatKhau);
                        taikhoan.MatKhau = hash;
                    }

                    SqlParameter[] param = new SqlParameter[2];

                    param[0] = new SqlParameter("@email", SqlDbType.NVarChar);
                    param[0].Value = taikhoan.Email;

                    param[1] = new SqlParameter("@matkhau", SqlDbType.NVarChar);
                    param[1].Value = taikhoan.MatKhau;

                    DataTable dt = dp.ExecuteProcQuery("sp_DangNhapTaiKhoan",ref param);

                    if (dt.Rows.Count > 0)
                    {
                        ViewBag.Result = true;
                        ViewBag.ErrorMessage = "Đăng nhập thành công";

                        TaiKhoan tk = new TaiKhoan();
                        tk.MaTaiKhoan = (int)dt.Rows[0]["mataikhoan"];
                        tk.Email = (string)dt.Rows[0]["email"];
                        tk.Ten = (string)dt.Rows[0]["ten"];
                        if (dt.Rows[0]["ngaysinh"] != DBNull.Value) tk.NgaySinh = (DateTime)dt.Rows[0]["ngaysinh"];
                        if (dt.Rows[0]["diachi"] != DBNull.Value) tk.DiaChi = (string)dt.Rows[0]["diachi"];
                        if (dt.Rows[0]["dienthoai"] != DBNull.Value) tk.DienThoai = (string)dt.Rows[0]["dienthoai"];

                        switch ((int)dt.Rows[0]["maloaitaikhoan"])
                        {
                            case 1:
                                tk.LoaiTaiKhoan = LoaiTaiKhoan.Admin;
                                Session.Add("taikhoan", tk);
                                return Redirect("/Admin/CanHo");
                            case 2:
                                tk.LoaiTaiKhoan = LoaiTaiKhoan.Member;
                                Session.Add("taikhoan", tk);
                                break;
                            case 3:
                                tk.LoaiTaiKhoan = LoaiTaiKhoan.Sales;
                                Session.Add("taikhoan", tk);
                                return Redirect("/Admin/");
                        };

                        switch ((int)dt.Rows[0]["trangthai"])
                        {
                            case 0:
                                tk.TrangThai = TrangThaiTaiKhoan.Deactive;
                                break;
                            case 1:
                                tk.TrangThai = TrangThaiTaiKhoan.Active;
                                break;
                        }
                    }
                    else
                    {
                        ViewBag.Result = false;
                        ViewBag.ErrorMessage = "Đăng nhập thất bại";
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Result = false;
                ViewBag.ErrorMessage = ex.Message;
            }
            return View("~/Views/Login/DangNhap.cshtml");
            
        }


        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}
