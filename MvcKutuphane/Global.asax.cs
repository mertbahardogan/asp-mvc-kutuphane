using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcKutuphane
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404) //eðer 2 slash kullanýlan bir hata varsa istediðim sayfaya yönlendiremiyorum.
            {
                Response.Redirect("error/404");
            }
        }

    }
}
