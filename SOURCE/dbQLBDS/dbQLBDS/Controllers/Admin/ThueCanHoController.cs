using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBDS.Controllers.Admin
{
    public class ThueCanHoController : Controller
    {
        //
        // GET: /Duong_/

        public ActionResult Index()
        {
            return View("~/Views/Admin/ThueCanHo/Index.cshtml");
        }

    }
}
