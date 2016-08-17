using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LuresWebApp.Startup))]
namespace LuresWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
