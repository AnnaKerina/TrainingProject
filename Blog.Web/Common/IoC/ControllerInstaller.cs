using Blog.Web.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Component = Castle.MicroKernel.Registration.Component;

namespace Blog.Web.Common.IoC
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<HomeController>()
                .ImplementedBy<HomeController>()
                .LifeStyle.Transient
            );

            container.Register(Component
                .For<AccountController>()
                .ImplementedBy<AccountController>()
                .LifeStyle.Transient
                );

            container.Register(Component
                .For<ManageController>()
                .ImplementedBy<ManageController>()
                .LifeStyle.Transient);
        }
    }
}