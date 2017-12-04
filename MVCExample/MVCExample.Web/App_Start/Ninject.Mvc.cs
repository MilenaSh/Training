using MVCExample.Data;
using MVCExample.Data.Repository;
using MVCExample.Services;
using MVCExample.Services.Contracts;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;

namespace MVCExample.Web.App_Start
{
    /// <summary>
    /// Resolves Dependencies Using Ninject for MVC
    /// </summary>
    public class NinjectResolver : IDependencyResolver
    {
        /// <summary>
        /// Represents the Core Kernel of the IOC Container
        /// </summary>
        public IKernel Kernel { get; private set; }

        /// <summary>
        /// Creates a new Instance of th Ninject Resolver with the modules Supplied
        /// </summary>
        /// <param name="modules">Modules to Load</param>
        public NinjectResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
            Kernel.Unbind<ModelValidatorProvider>();
        }

        /// <summary>
        /// Creates a new Instance of th Ninject Resolver by loading Modules
        /// from the Assembly Supplied
        /// </summary>
        /// <param name="assembly">Assembly to Load Modules</param>
        public NinjectResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Unbind<ModelValidatorProvider>();
            Kernel.Load(assembly);
        }

        /// <summary>
        /// Creates an Instance of an Object based on the Type information Supplied
        /// </summary>
        /// <param name="serviceType">Type of Object to resolve</param>
        /// <returns>Instance of the Object</returns>
        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        /// <summary>
        /// Returns all the instance based on the bindings of that type
        /// </summary>
        /// <param name="serviceType">Type to create Instances of</param>
        /// <returns>Instances of the Objects based on the Bindings</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }


    public class MvcModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IExampleContext>().To<ExampleContext>().InRequestScope();
            Kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            Kernel.Bind<ISuperheroService>().To<SuperheroService>().InRequestScope();
            Kernel.Bind<ICityService>().To<CityService>().InRequestScope();
            Kernel.Bind<ISupervillainService>().To<SupervillainService>().InRequestScope();
        }
    }

    /// <summary>
    /// Its job is to Register Ninject Modules and Resolve Dependencies Manually (If need be)
    /// </summary>
    public class NinjectContainer
    {
        private static NinjectResolver _resolver;

        /// <summary>
        /// Sets up the IOC using the Ninject Modules provided
        /// </summary>
        /// <param name="modules">Modules</param>
        public static void RegisterModules(NinjectModule[] modules)
        {
            _resolver = new NinjectResolver(modules);
            DependencyResolver.SetResolver(_resolver);
        }

        /// <summary>
        /// Sets up the IOC Container loading modules from the Currently Executing Assembly
        /// </summary>
        public static void RegisterAssembly()
        {
            _resolver = new NinjectResolver(Assembly.GetExecutingAssembly());

            //This is where the actual hookup to the MVC Pipeline is done.
            DependencyResolver.SetResolver(_resolver);
        }

        /// <summary>
        /// Manually Resolve Dependencies 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return _resolver.Kernel.Get<T>();
        }
    }


}