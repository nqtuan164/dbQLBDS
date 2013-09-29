using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbQLBDS.Models;

using System.Data.SqlClient;
using System.Data;


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
            taikhoan.NgayDangKy = DateTime.Now;
            taikhoan.TrangThai = 1;
            taikhoan.MaLoaiTaiKhoan = LoaiTaiKhoan.Member;

            using (DataProvider dp = new DataProvider())
            {
                if (dp.OpenConnect()) 
                {
                    SqlParameterCollection param = new SqlParameterCollection();

                    SqlCommand cmd = new SqlCommand("sp_DangKyTaiKhoan", dp.Connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(

                    
                }
                
            };


            return View("~/Views/Login/DangKy.cshtml", taikhoan);
        }

    }
}
