using ServiceCL;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace EvolentAssesment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();            
                   
            container.RegisterType<IContactService, ContactService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}