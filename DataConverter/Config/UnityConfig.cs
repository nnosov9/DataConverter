using System;
using DataConverter.Commands;
using Nikita.Lib;
using Unity;
using Unity.Lifetime;

namespace DataConverter.Config
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
            container.RegisterType<IDataProcessorCommandFactory, DataProcessorCommandFactory>(
                new PerThreadLifetimeManager());
        }           
    }
}
