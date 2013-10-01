using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbQLBDS.Models;

using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace dbQLBDS.Controllers.Login
{
    public class DangKyController : Controller
    {
        //
        // GET: /DangKy/

        public ActionResult Index()
        {
            return View("~/Views/Login/DangKy.cshtml");
        }

        [HttpPost]
        public ActionResult Index(TaiKhoan taikhoan)
        {
            try
            {
                if (taikhoan.MatKhau.Equals(taikhoan.XacNhanMatKhau))
                {

                    taikhoan.NgayDangKy = DateTime.Now;
                    taikhoan.TrangThai = 1;
                    taikhoan.MaLoaiTaiKhoan = LoaiTaiKhoan.Member;

                    using (MD5 md5hash = MD5.Create())
                    {
                        string hash = GetMd5Hash(md5hash, taikhoan.MatKhau);
                        taikhoan.MatKhau = hash;
                    }

                    DataProvider dp = new DataProvider();

                    SqlParameter[] param = new SqlParameter[9];
                    param[0] = new SqlParameter("@email", SqlDbType.NVarChar);
                    param[0].Value = taikhoan.Email;

                    param[1] = new SqlParameter("@matkhau", SqlDbType.NVarChar);
                    param[1].Value = taikhoan.MatKhau;

                    param[2] = new SqlParameter("@maloaitaikhoan", SqlDbType.Int);
                    param[2].Value = taikhoan.MaLoaiTaiKhoan;

                    param[3] = new SqlParameter("@ten", SqlDbType.NVarChar);
                    param[3].Value = taikhoan.Ten;

                    param[4] = new SqlParameter("@ngaysinh", SqlDbType.DateTime);
                    if (taikhoan.NgaySinh == null ) 
                        param[4].Value = DBNull.Value;
                    else
                        param[4].Value = taikhoan.NgaySinh;

                    param[5] = new SqlParameter("@diachi", SqlDbType.NVarChar);
                    if (taikhoan.DiaChi == null)
                    {
                        param[5].Value = DBNull.Value;
                    }
                    else
                    {
                        param[5].Value = taikhoan.DiaChi;
                    }
                    

                    param[6] = new SqlParameter("@dienthoai", SqlDbType.NVarChar);
                    if (taikhoan.DienThoai == null)
                    {
                        param[6].Value = DBNull.Value;
                    }
                    else { param[6].Value = taikhoan.DienThoai; }

                    param[7] = new SqlParameter("@ngaydangky", SqlDbType.DateTime);
                    param[7].Value = taikhoan.NgayDangKy;

                    param[8] = new SqlParameter("@trangthai", SqlDbType.Int);
                    param[8].Value = taikhoan.TrangThai;

                    dp.ExecuteProcNonQuery("sp_DangKyTaiKhoan",ref param);
                    ViewBag.Result = true;
                    ViewBag.ErrorMessage = "";
                }
                else
                {
                    ViewBag.Result = false;
                    ViewBag.ErrorMessage = "Xác nhận mật khẩu không trùng khớp";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Result = false;
                ViewBag.ErrorMessage = ex.Message;
            }

            return View("~/Views/Login/DangKy.cshtml");
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
