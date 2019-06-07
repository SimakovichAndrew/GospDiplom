using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using GospDiplom.BLL.Services;
using GospDiplom.BLL.Interfaces;

namespace GospDiplom.WEB.Util
{
    public class OrderModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IProcedureService>().To<ProcedureService>();
        }
    }
}