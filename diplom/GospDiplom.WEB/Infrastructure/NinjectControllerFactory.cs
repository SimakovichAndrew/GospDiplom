using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GospDiplom.WEB.Infrastructure
{
    //Реализация пользовательской фабрики контроллеров,
        //наследуясь от фабрики используемой по умолчанию

    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        
        public NinjectControllerFactory()
        {
            //создание контроллера
            ninjectKernel = new StandardKernel();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //получение объекта контроллера из контейнера
            //используя его тип
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            //конфигурирование контейнера
        }
    }
}