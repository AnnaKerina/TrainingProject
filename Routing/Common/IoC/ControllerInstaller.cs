﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Routing.Controllers;
using Component = Castle.MicroKernel.Registration.Component;

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

            container.Register(Component
                .For<PostController>()
                .ImplementedBy<PostController>()
                .LifeStyle.Transient
                );
        }
    }
}