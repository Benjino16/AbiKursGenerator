using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbiKursGenerator.Startup))]
namespace AbiKursGenerator
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
