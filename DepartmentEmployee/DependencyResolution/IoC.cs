
using DepartmentEmployee.Models;
using Microsoft.Practices.Unity;
using StructureMap;
namespace DepartmentEmployee {
    public static class IoC
    {
        public static IContainer Initialize()
        {
            
            return ObjectFactory.Container;
        }

        
    }
}