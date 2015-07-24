using Blog.Web.Identity;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Blog.Web.Common.IoC
{
    public class IdentityInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<UserManager>()
                .ImplementedBy<UserManager>()
                .LifeStyle.Transient
                );
        }
    }
}