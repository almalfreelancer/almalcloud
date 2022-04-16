using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ALMAL_Freelancer.Startup))]
namespace ALMAL_Freelancer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
