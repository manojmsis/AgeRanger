using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Web.Common;

namespace AgeRanger.Models
{
    public class NinjectRepositoriesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<AgeRangerContext>().InRequestScope();
        }
    }
}
