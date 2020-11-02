using Autofac;
using SmartHome.Mobile.Repository;
using SmartHome.Mobile.Services;
using SmartHome.Mobile.ViewModels;
using System;
using SmartHome.Mobile.Services.General;

namespace SmartHome.Mobile.Utilities
{
    public interface IDependencyResolver
    {
        object Resolve(Type typeName);
        T Resolve<T>();
    }

    public class AppContainer : IDependencyResolver
    {
        private IContainer _container;
        private static AppContainer _instance;

        public static AppContainer Instance => _instance ?? (_instance = new AppContainer());

        private AppContainer()
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<LightListViewModel>();

            //services - data
            builder.RegisterType<LightDataService>().As<ILightDataService>();

            //services - general
            builder.RegisterType<NavigationService>().As<INavigationService>();

            //General
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();
            builder.Register(c => Instance).As<IDependencyResolver>();

            _container = builder.Build();
        }


        public object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
