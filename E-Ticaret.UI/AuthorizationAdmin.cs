using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret.UI
{
    public class AuthorizationAdmin : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["Yetki"].ToString() != "Admin")
            {
                //Bu sayfaya gitme yetkiniz yok diye bir sayfa oluşturur
                //filterContext.Result = new  HttpUnauthorizedResult();
                HttpContext.Current.Session["ErrorMessage"] = "Bu Sayfaya girme yetkiniz yok.";
                filterContext.Result = new RedirectResult("/Login/Login");
            }
            //else if (HttpContext.Current.Session["Role"].ToString() == "Admin")
            //{
            //    filterContext.Result = new RedirectResult("/Admin/Admin");
            //}
        }
    }
}