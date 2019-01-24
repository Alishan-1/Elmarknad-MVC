using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Elmarknad.Startup))]
namespace Elmarknad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
