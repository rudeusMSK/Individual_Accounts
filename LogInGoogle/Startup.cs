using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LogInGoogle.Startup))]
namespace LogInGoogle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
