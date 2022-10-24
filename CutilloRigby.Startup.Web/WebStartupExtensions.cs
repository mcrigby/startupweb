using System.Reflection;
using CutilloRigby.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.Configuration
{
    public static class WebStartupExtensions
    {
        public static void WebConfigurationConfigureFromAssemblyContaining<TMarker>(this IConfiguration configuration, 
        #if NETCOREAPP3_1_OR_GREATER
            IWebHostEnvironment environment)
        #else
            IHostEnvironment environment)
        #endif
        {
            StartupHelpers.RunCustomStartupActionsFromAssemblyContaining<TMarker, IWebConfigurationConfigure>(
                x => x.Configure(environment, configuration));
        }

        public static void WebConfigurationConfigureFromAssembliesContaining(this IConfiguration configuration, 
        #if NETCOREAPP3_1_OR_GREATER
            IWebHostEnvironment environment,
        #else
            IHostEnvironment environment,
        #endif
            params Type[] assemblyMarkers)
        {
            StartupHelpers.RunCustomStartupActionsFromAssembliesContaining<IWebConfigurationConfigure>(
                x => x.Configure(environment, configuration), assemblyMarkers);
        }

        public static void WebConfigurationConfigureFromAssemblies(this IConfiguration configuration, 
        #if NETCOREAPP3_1_OR_GREATER
            IWebHostEnvironment environment,
        #else
            IHostEnvironment environment,
        #endif
            params Assembly[] assemblies)
        {
            StartupHelpers.RunCustomStartupActionsFromAssemblies<IWebConfigurationConfigure>(
                x => x.Configure(environment, configuration), assemblies);
        }
    }
}

namespace Microsoft.Extensions.Hosting
{
    public static class StartupExtensions
    {
        public static void ConfigureFromAssemblyContaining<TMarker>(this IApplicationBuilder applicationBuilder)
        {
            StartupHelpers.RunCustomStartupActionsFromAssemblyContaining<TMarker, IWebConfigure>(
                x => x.Configure(applicationBuilder));
        }

        public static void ConfigureFromAssembliesContaining(this IApplicationBuilder applicationBuilder,
            params Type[] assemblyMarkers)
        {
            StartupHelpers.RunCustomStartupActionsFromAssembliesContaining<IWebConfigure>(
                x => x.Configure(applicationBuilder), assemblyMarkers);
        }

        public static void ConfigureFromAssemblies(this IApplicationBuilder applicationBuilder, params Assembly[] assemblies)
        {
            StartupHelpers.RunCustomStartupActionsFromAssemblies<IWebConfigure>(
                x => x.Configure(applicationBuilder), assemblies);
        }
    }
}
