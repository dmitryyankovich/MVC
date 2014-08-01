using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myProject.Startup))]
namespace myProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
