using Microsoft.AspNetCore.Builder;

namespace CutilloRigby.Startup;

public interface IWebConfigure : IStartup
{
    void Configure(IApplicationBuilder applicationBuilder);
}
