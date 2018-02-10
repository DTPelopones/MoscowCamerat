using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoscowCamerata2.Startup))]
namespace MoscowCamerata2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
