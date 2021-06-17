using System;
using harperdb_crud.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace harperdb_crud.Utility
{
    public static class DependencyInjector
    {
       public static void AddDependency(this IServiceCollection service)
        {
            service.AddSingleton<IUserRepository, UserRepository>();
            service.AddSingleton<IConfigurationHandler, ConfigurationHandler>();
            service.AddSingleton<IDomainRepository, DomainRepository>();
            service.AddSingleton<ISchemaRepository, SchemaRepository>();
        }
    }
}
