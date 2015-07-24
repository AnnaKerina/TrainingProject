using Blog.IStore;
using Blog.Store.Entity;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Blog.Web.Common.IoC
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IDatabaseContext>()
                .ImplementedBy<DatabaseContext>()
                .DependsOn(Dependency.OnValue("nameOrConnectionString", "DefaultConnection"))
                .LifeStyle.Transient
                );

            container.Register(Component
                .For<IUserStore>()
                .ImplementedBy<UserStore>()
                .LifeStyle.Transient);

            container.Register(Component
                .For<IPostStore>()
                .ImplementedBy<PostStore>()
                .LifeStyle.Transient
                );

            container.Register(Component
                .For<IUnitOfWork>()
                .ImplementedBy<UnitOfWork>()
                .LifeStyle.Transient
                );
        }
    }
}