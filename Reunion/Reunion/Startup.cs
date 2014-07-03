using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reunion.Startup))]
namespace Reunion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
