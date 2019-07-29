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
        //public HomeController()
        //{
        //    Mapper.Initialize(cfg => cfg.CreateMap<KioskDTO, KioskViewModel>());
        //}

        public int PageCom = 25;

        IProcedureService orderService;


        public HomeController(IProcedureService serv)
        {
            orderService = serv;
        }



        [HttpGet]
        //[Authorize (Roles ="admin")]
        public ActionResult Index(int page = 1)
        {
            //List<InputViewModels> listInput = new List<InputViewModels>();
            //int i = 0;
            //foreach (var item in orderService.GetKiosks())
            //{
            //    listInput.Add(new InputViewModels() { 
            //        Kiosk = orderService.GetKiosks().ElementAt(i),
            //        OrgName = orderService.GetOrganizations().Where(x => x.OrganizationId == orderService.GetKiosks().ElementAt(i).OrganizationId ).First().OrgName,
            //        Dogovor = orderService.GetOrganizations().Where(d=>d.OrganizationId== orderService.GetKiosks().ElementAt(i).OrganizationId).First().Dogovor,
            //        PagingInfo = new PagingInfo
            //        {
            //            CurrentPage = page,
            //            ItemsPerPage = PageCom,
            //            TotalItems = orderService.GetKiosks().Count()
            //        },
            //    });
            //    i++;
            //}
            if(!User.IsInRole("admin")&&!User.IsInRole("moderator")&&!User.IsInRole("user"))
            {

              return RedirectToAction ("IndexIndication","IndicationInput");
            }
            //IEnumerable<AllTable> tableKioski = orderService.GetAllKioski();

            IEnumerable<SectionDTO> section = orderService.GetSections();
            IEnumerable<KioskDTO> kiosks = orderService.GetKiosks();
           // ViewBag.totalInfo = tableKioski;
            //InputViewModels listInput = new InputViewModels
            SectionModel listInput = new SectionModel
            {
                Kiosks=kiosks,
                Sections = section
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = orderService.GetAllKioski().Count()
                }

            };


        //TownListViewModel model = new TownListViewModel
        //{
        //    KioskId = SelectTownId,
        //    GetSchetchiks = repository.GetSchetchiks()
        //       .Where(p => topicname == null || p.ComTopicId == SelectTownId)
        //       .OrderBy(p => p.CommentId)
        //       .Skip((page - 1) * PageCom)
        //       .Take(PageCom),
        //    PagingInfo = new PagingInfo
        //    {
        //        CurrentPage = page,
        //        ItemsPerPage = PageCom,
        //        TotalItems = topicname == null ?
        //        repository.GetSchetchiks().Count() :
        //        repository.GetSchetchiks().Where(e => e.ComTopicName == topicname).Count()
        //    },
        //    CurrentTownName = topicname,
        //    Autor = User.Identity.LastName
        //};

  return View(listInput);
        }


        //[HttpGet]
        public ActionResult BaseUpDate(int page = 1)
        {
            orderService.UpdateKiosks();
            IEnumerable<AllTable> tableKioski = orderService.GetAllKioski();
            ViewBag.totalInfo = tableKioski;
            InputViewModels listInput = new InputViewModels
            {
                AllKioski = tableKioski
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = orderService.GetAllKioski().Count()
                }

            };

            return View("Index", listInput);
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