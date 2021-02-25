using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BibliotekaProgmat.Startup))]
namespace BibliotekaProgmat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
