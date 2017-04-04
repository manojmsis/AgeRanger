using Ninject.Modules;
using Ninject.Web.Common;
using AgeRanger.Models;
using AgeRanger.Services.Contracts;

namespace AgeRanger.Services
{
    public class NinjectServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IpersonService>().To<PersonService>().InRequestScope();
            Bind<IAgeGroupService >().To<AgeGroupService>().InRequestScope();
            Kernel?.Load(new INinjectModule[]
           {
                new NinjectRepositoriesModule()
           });
        }
    }
}
