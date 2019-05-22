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

        }

        public HomeController(IProcedureService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<KioskDTO> phoneDtos = orderService.GetKiosks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KioskDTO, KioskViewModel>()).CreateMapper();
            var phones = mapper.Map<IEnumerable<KioskDTO>, List<KioskViewModel>>(phoneDtos);
            return View(phones);

            //// получаем из бд все объекты Book
            //IEnumerable<Kiosk> books = db.Kiosks;
            //// передаем все объекты в динамическое свойство Books в ViewBag
            //ViewBag.Books = books;
            //// возвращаем представление
            //return View();

        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                KioskDTO phone = orderService.GetKiosk(id);
                var order = new OrderViewModel { KioskId = phone.KioskId };

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
                var orderDto = new KioskDTO { KioskId = order.KioskId, ModelKioska = order.Town, Nomer = order.KioskNumber };
                orderService.MakeProcedure(orderDto);
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