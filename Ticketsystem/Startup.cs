using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ticketsystem.Startup))]
namespace Ticketsystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
