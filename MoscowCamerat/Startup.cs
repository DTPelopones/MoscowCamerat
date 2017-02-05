using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoscowCamerat.Startup))]
namespace MoscowCamerat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
