using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ONPE.WEB.Startup))]
namespace ONPE.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
