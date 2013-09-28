using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbQLBDS.Models;
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
        public ActionResult DangKy(TaiKhoan taikhoan)
        {

            return View();
        }

    }
}
