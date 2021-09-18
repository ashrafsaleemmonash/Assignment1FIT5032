using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment1FIT5032.Startup))]
namespace Assignment1FIT5032
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
