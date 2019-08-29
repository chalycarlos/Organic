using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Organic.Backend.Startup))]
namespace Organic.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
