using Microsoft.AspNetCore.Builder;

namespace CutilloRigby.Startup;

public interface IApplicationConfigure : IStartup
{
    void Configure(IApplicationBuilder applicationBuilder);
}
