using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoxingSite.Startup))]
namespace BoxingSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
