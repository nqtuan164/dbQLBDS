using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbQLBDS.Controllers.Login
{
    public class DangXuatController : Controller
    {
        //
        // GET: /DangXuat/

        public ActionResult Index()
        {
            Session["taikhoan"] = null;
            Session.Abandon();

            return Redirect("/");
        }

    }
}
