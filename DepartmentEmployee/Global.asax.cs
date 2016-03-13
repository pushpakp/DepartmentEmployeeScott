using DepartmentEmployee.Controllers;
using DepartmentEmployee.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DepartmentEmployee
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IoCUnity.UniteDepContainer();

        }
    }

    public static class IoCUnity
    {
      

        public static void UniteDepContainer()
        {
            var con = new UnityContainer();
            con.RegisterType<IDepartmentDataSource, DepartmentDb>();

            DependencyResolver.SetResolver(new depResolver(con));
        }
    }

    public class depResolver : IDependencyResolver
    {
        private IUnityContainer _unityCon;
        public depResolver(IUnityContainer unityCon)
        {
            _unityCon = unityCon;

        }
        public object GetService(Type serviceType)
        {
            try
            {
                return _unityCon.Resolve(serviceType);

            }
            catch (Exception)
            {
                
                return null;
            }

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityCon.ResolveAll(serviceType);

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
