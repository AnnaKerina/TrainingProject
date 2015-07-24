using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Blog.Web.Common.IoC;
using Castle.Windsor;

namespace Blog.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public static IWindsorContainer Container;
        protected void Application_Start()
        {
            Container = new WindsorContainer()
                .Install(new ControllerInstaller())
                .Install(new PersistenceInstaller());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
