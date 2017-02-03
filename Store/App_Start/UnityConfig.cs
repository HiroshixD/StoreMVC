using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ETStore.Models;
using DataStore.Repo;
using SVCStore.Interfaces;


namespace Store.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {

            container.RegisterType<IRepository<Client>, Repository<Client>>();
            container.RegisterType<IRepository<Product>, Repository<Product>>();
            container.RegisterType<IRepository<Category>, Repository<Category>>();
            container.RegisterType<IRepository<Invoice_Header>, Repository<Invoice_Header>>();
            container.RegisterType<IRepository<Invoice_Detail>, Repository<Invoice_Detail>>();


        }
    }
}
