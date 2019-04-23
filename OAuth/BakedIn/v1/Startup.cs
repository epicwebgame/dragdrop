using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(v1.Startup))]
namespace v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
