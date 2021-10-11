using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RockClimbingDb.Startup))]
namespace RockClimbingDb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
