using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Toman296NTermProject.Startup))]
namespace Toman296NTermProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
