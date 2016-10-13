using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DFF.Startup))]
namespace DFF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
