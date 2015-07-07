using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Castle.Windsor;
using Models;
using Routing.Common.IoC;
using Routing.Models;

namespace Routing
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {

        public static IWindsorContainer Container;

        protected void Application_Start()
        {

            Container = new WindsorContainer()
                .Install(new ControllerInstaller())
                .Install(new PersistenceInstaller());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(typeof(CastleWindsorControllerFactory));

            Mapper.CreateMap<AddUserViewModel, User>();
            Mapper.CreateMap<AddPostViewModel, Post>();
            Mapper.CreateMap<Post, ViewPostViewModel>();
        }
    }
}