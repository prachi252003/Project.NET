using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingPortal.WebMvc.Startup))]
namespace TrainingPortal.WebMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
