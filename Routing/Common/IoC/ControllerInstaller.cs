using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Routing.Controllers;

namespace Routing.Common.IoC
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
        }
    }
}