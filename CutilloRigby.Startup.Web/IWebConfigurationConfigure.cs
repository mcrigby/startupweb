using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CutilloRigby.Startup;

public interface IWebConfigurationConfigure : IStartup
{
    #if NETCOREAPP3_1_OR_GREATER
        void Configure(IWebHostEnvironment hostingEnvironment, IConfiguration configuration);
    #else
        void Configure(IHostEnvironment hostingEnvironment, IConfiguration configuration);
    #endif

}
