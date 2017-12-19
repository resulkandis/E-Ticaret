using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [AuthorizationAdmin]
        public ActionResult Admin()
        {
            return View();
        }
    }
}