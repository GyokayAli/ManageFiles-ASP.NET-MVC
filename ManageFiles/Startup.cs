using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageFiles.Startup))]
namespace ManageFiles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
