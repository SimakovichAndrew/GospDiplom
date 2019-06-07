using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Web.Services.Description;
using GospDiplom.BLL.Interfaces;
using GospDiplom.BLL.DTO;
using GospDiplom.WEB.Models;
using AutoMapper;

namespace GospDiplom.WEB.Controllers
{
    public class SchetchikInputController : Controller
    {
        IProcedureService db;
        public SchetchikInputController(IProcedureService orderService)
        {
            db = orderService;
        }

        // GET: Temp
        public ActionResult Index()
        {
            //// получаем из бд все объекты Book
            //IEnumerable<Kiosk> books = db.Kiosks;
            //// передаем все объекты в динамическое свойство Books в ViewBag
            //ViewBag.Books = books;
            //// возвращаем представление
            //return View()

            //db.MakeProcedure();
            IEnumerable<KioskDTO> commentDtos = db.GetKiosks();
            var mapperkiosk = new MapperConfiguration(cfg => cfg.CreateMap<KioskDTO, KioskViewModel>()).CreateMapper();
            var kiosks = mapperkiosk.Map<IEnumerable<KioskDTO>, List<KioskViewModel>>(commentDtos);
            ViewBag.dinamic = kiosks;
            IEnumerable<SchetchikDTO> counters = db.GetCounters();
            var mappercounter = new MapperConfiguration(cfg => cfg.CreateMap<SchetchikDTO, SchetchikViewModel>()).CreateMapper();
            var counter = mappercounter.Map<IEnumerable<SchetchikDTO>, List<SchetchikViewModel>>(counters);
            IEnumerable<IndicationDTO> indications = db.GetIndications();
            var mapperindication = new MapperConfiguration(cfg => cfg.CreateMap<IndicationDTO, IndicationViewModel>()).CreateMapper();
            var indication = mappercounter.Map<IEnumerable<IndicationDTO>, List<IndicationViewModel>>(indications);
            double total = 0;
           
            ViewBag.totalMessage = counter.AsEnumerable();
            List<InputViewModels> totalInfo = new List<InputViewModels>();
            for (int i = 0; i < kiosks.Count; i++)
            {

                //InputViewModels countes = new InputViewModels();
                //countes.Kiosk = new KioskViewModel { Kiosk = kiosks.ElementAt(i).Kiosk, Nomer = kiosks.ElementAt(i).Nomer, Town = kiosks.ElementAt(i).Town };
                //countes.Counetr = new SchetchikViewModel { SchetchikId = counters.ElementAt(i).SchetchiId/*, IdKiosk = counters.ElementAt(i).Kiosk.KioskId*/ };//(counters.Where(p => p.Kiosk.Nomer == i.ToString()).First()).SchetchiId
                //countes.Indication = new IndicationViewModel { IndicationId = indication.ElementAt(i).IndicationId, Tarif1 = indication.ElementAt(i).Tarif1, Month = indication.ElementAt(i).Month};
               

               // totalInfo.Add(countes);
            }


            // Convert the entered strings into integers numbers and add.
           // total = count.Tarif1 + count.Tarif2; //num1.AsInt() + num2.AsInt();
                 ViewBag.Message = "Сумма = " + total;

            return View(/*totalInfo*/);
        }
    }
}