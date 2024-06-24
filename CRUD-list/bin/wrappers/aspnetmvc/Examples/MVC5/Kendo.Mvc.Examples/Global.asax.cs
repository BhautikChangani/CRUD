using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Kendo.Mvc.Examples.Extensions;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Editor;
using Microsoft.Extensions.DependencyInjection;

namespace Kendo.Mvc.Examples
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var services = new ServiceCollection();
            ConfigureServices(services);

            ModelBinderConfig.RegisterModelBinders(ModelBinders.Binders);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDirectoryBrowser, DirectoryBrowser>();
            services.AddScoped<IDirectoryPermission, DirectoryPermission>();
            services.AddScoped<IVirtualPathProvider, VirtualPathProviderWrapper>();
            services.AddScoped<IThumbnailCreator, ThumbnailCreator>();
            services.AddScoped<IImageResizer, FitImageResizer>();
            services.AddControllers(Assembly.GetExecutingAssembly());

            var provider = services.BuildServiceProvider(new ServiceProviderOptions()
            {
                ValidateScopes = true
            });

            ControllerBuilder.Current.SetControllerFactory(new DiControllerFactory(provider));
        }
    }
}