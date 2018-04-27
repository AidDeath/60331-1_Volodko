using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_60331_1_Volodko.Startup))]
namespace _60331_1_Volodko
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
