using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllers(
            this IServiceCollection services,
            Assembly assembly)
        {
            var type = typeof(IController);

            var controllers = assembly.GetExportedTypes().Where(
                t =>
                    !t.IsAbstract
                    && !t.IsGenericTypeDefinition).Where(
                t =>
                    type.IsAssignableFrom(t)
                    || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase));

            foreach (var controller in controllers)
            {
                services.AddTransient(controller);
            }

            return services;
        }
    }
}