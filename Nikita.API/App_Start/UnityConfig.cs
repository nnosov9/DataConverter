using System;
using Nikita.API.Controllers.Commands;
using Nikita.API.Controllers.Commands.Interfaces;
using Nikita.Lib;
using Unity;
using Unity.Lifetime;

namespace Nikita.API
{
    public static class UnityConfig
    {

        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        public static void RegisterTypes(UnityContainer container)
        {
            NikitaLibUnityConfig.Register(container);
            container.RegisterType<IPeopleCommandFactory, PeopleCommandFactory>(
                new PerThreadLifetimeManager());
 
        }           
    }
}
