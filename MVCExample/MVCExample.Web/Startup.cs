using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCExample.Web.Startup))]
namespace MVCExample.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
