using AutoMapper;
using GospDiplom.BLL.DTO;
using GospDiplom.BLL.Interfaces;
using GospDiplom.BLL.Infrastructure;
using GospDiplom.WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationException = GospDiplom.BLL.Infrastructure.ValidationException;

namespace GospDiplom.WEB.Controllers
{
    public class HomeController : Controller
    {
        IProcedureService orderService;

        public HomeController()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<KioskDTO, KioskViewModel>());
        }

        public HomeController(IProcedureService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<KioskDTO> kioskDtos = orderService.GetKiosks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KioskDTO, KioskViewModel>()).CreateMapper();
            List<KioskViewModel>  kiosks = mapper.Map<IEnumerable<KioskDTO>, List<KioskViewModel>>(kioskDtos);
           // List<KioskViewModel> kiosks = mapper.Map<IEnumerable<KioskDTO>, List<KioskViewModel>>(kioskDtos);
            //  IEnumerable<KioskViewModel> kioskViews = kiosks.AsEnumerable();

         

            IEnumerable<OrganizationDTO> OrgDtos = orderService.GetOrganizations();
            var mapperOrg = new MapperConfiguration(cfg => cfg.CreateMap<OrganizationDTO, OrganizationViewModel>()).CreateMapper();
            var organization = mapperOrg.Map<IEnumerable<OrganizationDTO>, List<OrganizationViewModel>>(OrgDtos);
            //List<OrganizationViewModel> organizationViews = organization;

            List<InputViewModels> listInput = new List<InputViewModels>();

            for (int i=1; i<kiosks.Count;i++)
            {
                listInput.Add(new InputViewModels() { Kiosk = kiosks.ElementAt(i), OrgName = OrgDtos.ElementAt(i).OrgName });
            }

   ViewBag.OrgName = orderService.GetKiosk(3);
            //for (int i = 1; i< 210; i++)
            //{
            //    InputViewModels kioski = new InputViewModels
            //    {
            //        GetKiosk = /*kioskViews.ElementAt(i)*/ kiosks.ElementAt(1),
            //        // GetOrg = organizationViews.ElementAt(i)
            //       OrgName = "Энергосбыт" //orderService.GetOrganizations().Where(x=>x.OrganizationId==1).First().OrgName
            //};

            //    listInput.Add(kioski);
            //}

            //// получаем из бд все объекты Book
            //IEnumerable<Kiosk> books = db.Kiosks;
            //// передаем все объекты в динамическое свойство Books в ViewBag
            //ViewBag.Books = books;
            //// возвращаем представление
            //return View();
            //IEnumerable<AllValue> kioskDtos = orderService.MakeProcedure();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AllValue, IndicationViewModel>()).CreateMapper();
            //var kiosks = mapper.Map<IEnumerable<AllValue>, List<IndicationViewModel>>(kioskDtos);
            //ViewBag.OrgName = orderService.GetKiosk(3);

            return View(listInput);
            //return View(kiosks);
        }

        public ActionResult MakeOrder()
        {
            try
            {
                //KioskDTO phone = orderService.GetKiosk(id);
                //var order = new InputViewModels { Kiosk = new KioskViewModel { }, Counetr = new SchetchikViewModel { }, Indication = new IndicationViewModel { } };
                IndicationViewModel order = new IndicationViewModel
                {

                };
                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
               // var orderDto = new KioskViewModel { Kiosk = order.Kiosk, ModelKioska = order.Town, Nomer = order.KioskNumber };
               // orderService.MakeProcedure(orderDto.Kiosk);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        //protected override void Dispose(bool disposing)
        //{
        //    orderService.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}