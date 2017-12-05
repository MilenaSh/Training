using MVCExample.Infrastructure;
using System;
using System.Linq;

namespace MVCExample.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            var autoMapperConfig = new AutoMapperConfiguration();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("MVCExample")).ToArray();
            autoMapperConfig.Execute(assemblies);
        }
    }
}