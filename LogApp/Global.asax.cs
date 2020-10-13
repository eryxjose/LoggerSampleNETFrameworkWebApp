using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LogApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_Error(object sender, EventArgs e)
        {

            var ex = Server.GetLastError().GetBaseException();

            log.Error("Erro.", ex);

            Server.ClearError();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");

            if (ex.GetType() == typeof(HttpException))
            {
                var httpException = (HttpException)ex;
                var code = httpException.GetHttpCode();

                switch (code)
                {
                    case 401:
                        routeData.Values.Add("action", "NotAuthorized");
                        break;
                    case 404:
                        routeData.Values.Add("action", "NotFound");
                        break;
                    default:
                        routeData.Values.Add("action", "Index?auth=s");
                        break;
                }
            }
            else
            {
                routeData.Values.Add("action", "Index?auth=s");
            }

            routeData.Values.Add("error", ex);

            IController errorController = new webportos.Controllers.ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}
