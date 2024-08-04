using System;
using System.Reflection;
using CutilloRigby.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting;

public static class StartupExtensions
{
    public static void ConfigureFromAssemblyContaining<TMarker>(this IApplicationBuilder applicationBuilder)
    {
        StartupHelpers.RunCustomStartupActionsFromAssemblyContaining<TMarker, IApplicationConfigure>(
            x => x.Configure(applicationBuilder));
    }

    public static void ConfigureFromAssembliesContaining(this IApplicationBuilder applicationBuilder,
        params Type[] assemblyMarkers)
    {
        StartupHelpers.RunCustomStartupActionsFromAssembliesContaining<IApplicationConfigure>(
            x => x.Configure(applicationBuilder), assemblyMarkers);
    }

    public static void ConfigureFromAssemblies(this IApplicationBuilder applicationBuilder, params Assembly[] assemblies)
    {
        StartupHelpers.RunCustomStartupActionsFromAssemblies<IApplicationConfigure>(
            x => x.Configure(applicationBuilder), assemblies);
    }

    public static void PostBuildConfigureFromAssemblyContaining<TMarker>(this IWebHost webHost, IServiceScope serviceScope)
    {
        StartupHelpers.RunCustomStartupActionsFromAssemblyContaining<TMarker, IPostBuildApplicationConfigure>(
            x => x.PostBuildConfigure(webHost, serviceScope));
    }

    public static void PostBuildConfigureFromAssembliesContaining(this IWebHost webHost, IServiceScope serviceScope, params Type[] assemblyMarkers)
    {
        StartupHelpers.RunCustomStartupActionsFromAssembliesContaining<IPostBuildApplicationConfigure>(
            x => x.PostBuildConfigure(webHost, serviceScope), assemblyMarkers);
    }

    public static void PostBuildConfigureFromAssemblies(this IWebHost webHost, IServiceScope serviceScope, params Assembly[] assemblies)
    {
        StartupHelpers.RunCustomStartupActionsFromAssemblies<IPostBuildApplicationConfigure>(
            x => x.PostBuildConfigure(webHost, serviceScope), assemblies);
    }
}
