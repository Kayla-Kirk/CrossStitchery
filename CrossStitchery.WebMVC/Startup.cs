using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossStitchery.WebMVC.Startup))]
namespace CrossStitchery.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
