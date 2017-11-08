using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlugaGo.Startup))]
namespace AlugaGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
