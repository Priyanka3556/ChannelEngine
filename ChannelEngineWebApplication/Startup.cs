using ChannelEngineShared;
using ChannelEngineShared.Configuration;
using ChannelEngineWebApplication.Behaviors;
using ChannelEngineWebApplication.Controllers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SharedLibrary;
using System.Reflection;

namespace ChannelEngineWebApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ChannelEngineSharedConfigOptions>(
              Configuration.GetSection(ChannelEngineSharedConfigOptions.ServiceConfiguration));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddSingleton<ISharedManager, SharedManager>();
            services.AddMediatR((typeof(Startup)));
        }
    }
}
