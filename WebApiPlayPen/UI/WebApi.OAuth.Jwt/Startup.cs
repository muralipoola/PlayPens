using Microsoft.Owin;
using Owin;
using WebApi.OAuth.Jwt;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApi.OAuth.Jwt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}