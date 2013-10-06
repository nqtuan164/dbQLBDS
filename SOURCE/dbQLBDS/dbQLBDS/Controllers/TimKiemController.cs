using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbQLBDS.Controllers
{
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/

        public ActionResult Index()
        {
            return PartialView("~/Views/Shared/TimKiem.cshtml");
        }

    }
}
