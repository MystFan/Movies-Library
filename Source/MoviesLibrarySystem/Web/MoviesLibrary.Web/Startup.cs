using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesLibrary.Web.Startup))]
namespace MoviesLibrary.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
