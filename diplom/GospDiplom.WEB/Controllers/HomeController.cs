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

        //public HomeController()
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap<KioskDTO, KioskViewModel>());
        //}

        public HomeController(IProcedureService serv)
        {
            orderService = serv;
        }



        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<KioskDTO> kioskDtos = orderService.GetKiosks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KioskDTO, KioskViewModel>()).CreateMapper();
            List<KioskViewModel>  kiosks = mapper.Map<IEnumerable<KioskDTO>, List<KioskViewModel>>(kioskDtos);
           
            IEnumerable<OrganizationDTO> OrgDtos = orderService.GetOrganizations();
            var mapperOrg = new MapperConfiguration(cfg => cfg.CreateMap<OrganizationDTO, OrganizationViewModel>()).CreateMapper();
            var organization = mapperOrg.Map<IEnumerable<OrganizationDTO>, List<OrganizationViewModel>>(OrgDtos);
            

            List<InputViewModels> listInput = new List<InputViewModels>();

            for (int i=0; i<kiosks.Count;i++)
            {
                listInput.Add(new InputViewModels() {
                    Kiosk = kiosks.ElementAt(i),
                    OrgName = organization.Where(x => x.OrganizationId == kiosks.ElementAt(i).OrganizationId ).First().OrgName,
                    Dogovor = organization.Where(d=>d.OrganizationId==kiosks.ElementAt(i).OrganizationId).First().Dogovor
                });
            }

            return View(listInput);
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