 
using Nikita.Lib.Data;
using Nikita.Lib.Domain;
using Nikita.Lib.Interfaces;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Nikita.Lib
{
    public class NikitaLibUnityConfig
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IParser, PersonParser>("recordParser",new HierarchicalLifetimeManager());
            container.RegisterType<IParser, HeaderParser>("headerParser",new HierarchicalLifetimeManager());
            container.RegisterType<IParser, DataFileParser<Person>>(new HierarchicalLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<IParser>("headerParser"), 
                new ResolvedParameter<IParser>("recordParser")));


            container.RegisterType<IMyRepository<Person>, PersonRepository>(new PerThreadLifetimeManager());

            container.RegisterType<IDataStorage, DataStorage>(new PerThreadLifetimeManager());

            container.RegisterType<IService, PersonService>(new PerThreadLifetimeManager());

        }
    }
}
