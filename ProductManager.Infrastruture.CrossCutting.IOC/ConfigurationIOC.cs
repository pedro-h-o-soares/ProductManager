using Autofac;
using ProductManager.Application.Interfaces;
using ProductManager.Application.Service;
using ProductManager.Domain.Core.Interfaces.Repositories;
using ProductManager.Domain.Core.Services;
using ProductManager.Domain.Services.Services;
using ProductManager.Infraestructure.Repository.Repositories;
using ProductManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using ProductManager.Infrastruture.CrossCutting.Adapter.Map;

namespace ProductManager.Infrastruture.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {

            #region IOC Register

            #region IOC Application
            builder.RegisterType<ApplicationServiceProduct>().As<IApplicationServiceProduct>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceProduct>().As<IServiceProduct>();
            #endregion

            #region IOC Repositories SQL
            builder.RegisterType<RepositoryProduct>().As<IRepositoryProduct>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperProduct>().As<IMapperProduct>();
            #endregion

            #endregion
        }
    }
}
