using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CutilloRigby.Startup;

public interface IPostBuildApplicationConfigure : IStartup
{
    void PostBuildConfigure(IWebHost webHost, IServiceScope serviceScope);
}
