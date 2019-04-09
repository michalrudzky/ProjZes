using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjZes.Startup))]
namespace ProjZes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
