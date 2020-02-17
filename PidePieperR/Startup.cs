using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PidePieperR.Startup))]
namespace PidePieperR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
