using GospDiplom.BLL.Interfaces;
using GospDiplom.BLL.Service;
using Ninject.Modules;

namespace GospDiplom.WEB.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProcedureService>().To<ProcedureService>();
        }
    }
}