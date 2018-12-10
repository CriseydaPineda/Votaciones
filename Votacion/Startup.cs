using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Votacion.Startup))]
namespace Votacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
