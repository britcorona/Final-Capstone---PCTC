using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Final_Capstone___PCTC.Startup))]
namespace Final_Capstone___PCTC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
