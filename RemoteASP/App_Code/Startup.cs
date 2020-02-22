using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RemoteASP.Startup))]
namespace RemoteASP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
