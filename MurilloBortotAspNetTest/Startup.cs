using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MurilloBortotAspNetTest.Startup))]
namespace MurilloBortotAspNetTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
