using System.Linq;
using System.Reflection;
using ClientBase.Infrastructure;
using ClientBase.Infrastructure.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GoodsPlan.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreEntities(this IServiceCollection services)
        {
            var coreModule = Assembly.Load(new AssemblyName("ClientBase.Core"));
            var types = coreModule.DefinedTypes.Select(t => t.AsType()).ToList();

            GlobalConfiguration.EntitiesTypes = types.Where(x => x.GetTypeInfo().IsSubclassOf(typeof(EntityBase)) && !x.GetTypeInfo().IsAbstract).ToList();

            return services;
        }
    }
}
