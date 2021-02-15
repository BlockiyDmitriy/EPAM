using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task5.WebClient.Startup))]
namespace Task5.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
