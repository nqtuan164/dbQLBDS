using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBDS.Controllers.Admin
{
    public class CanHoController : Controller
    {
        //
        // GET: /CanHo/

        public ActionResult Index()
        {
            return View("~/Views/Admin/CanHo/Index.cshtml");
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
