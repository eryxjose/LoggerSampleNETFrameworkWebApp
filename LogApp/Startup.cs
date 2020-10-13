using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogApp.Startup))]
namespace LogApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
