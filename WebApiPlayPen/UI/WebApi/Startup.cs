using Microsoft.Owin;
using Owin;
using WebApiPlayPen.Api;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApiPlayPen.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
