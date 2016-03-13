using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DepartmentEmployee.Startup))]
namespace DepartmentEmployee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
