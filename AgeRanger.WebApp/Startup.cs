using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgeRanger.WebApp.Startup))]
namespace AgeRanger.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
