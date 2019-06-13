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
        int viewTemp = 0;
        public SchetchikInputController(IProcedureService orderService)
        {
            db = orderService;
        }

        // GET: Temp
        [HttpGet]
        public ActionResult Index(int page=1)
        {
            for (int i = 0; i < 1; i++)
            {

            
            //IEnumerable<KioskDTO> commentDtos = db.GetKiosks();
            //var mapperkiosk = new MapperConfiguration(cfg => cfg.CreateMap<KioskDTO, KioskViewModel>()).CreateMapper();
            //var kiosks = mapperkiosk.Map<IEnumerable<KioskDTO>, List<KioskViewModel>>(commentDtos);
            //ViewBag.dinamic = kiosks;

            //IEnumerable<SchetchikDTO> counters = db.GetCounters();
            //var mappercounter = new MapperConfiguration(cfg => cfg.CreateMap<SchetchikDTO, SchetchikViewModel>()).CreateMapper();
            //var counter = mappercounter.Map<IEnumerable<SchetchikDTO>, List<SchetchikViewModel>>(counters);

            //IEnumerable<IndicationDTO> indications = db.GetIndications();
            //var mapperindication = new MapperConfiguration(cfg => cfg.CreateMap<IndicationDTO, IndicationViewModel>()).CreateMapper();
            //var indication = mappercounter.Map<IEnumerable<IndicationDTO>, List<IndicationViewModel>>(indications);
          }


            IEnumerable<AllCounter> listTotalInfo = db.GetAllCounters();
            int PageCom = 10;
            

            SchetchikViewModel CounterInfo = new SchetchikViewModel
            {
                AllCounters = listTotalInfo
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = db.GetAllCounters().Count()
                }

            };

            //for (int i = 0; i < db.GetCounters().Count(); i++)
            //{
            //    listTotalInfo.Add(new InputViewModels {

            //        //Counetr = db.GetCounters().ElementAt(i),
            //        //Kiosk = db.GetKiosks().Where(x => x.KioskId == db.GetCounters().ElementAt(i).KioskId).First(),
            //        //Indication = db.GetIndications().Where(y => y.SchetchikId == db.GetCounters().ElementAt(i).SchetchikId).First(),
            //        //OrgName = db.GetIndications().Where(y => y.SchetchikId == db.GetCounters().ElementAt(i).SchetchikId).First().Month.ToString("MMMM")
            //    });

                //InputViewModels countes = new InputViewModels();
                //countes.Kiosk = new KioskViewModel { Kiosk = kiosks.ElementAt(i).Kiosk, Nomer = kiosks.ElementAt(i).Nomer, Town = kiosks.ElementAt(i).Town };
                //countes.Counetr = new SchetchikViewModel { SchetchikId = counters.ElementAt(i).SchetchikId/*, IdKiosk = counters.ElementAt(i).Kiosk.KioskId*/ };//(counters.Where(p => p.Kiosk.Nomer == i.ToString()).First()).SchetchikId
                //countes.Indication = new IndicationViewModel { IndicationId = indication.ElementAt(i).IndicationId, Tarif1 = indication.ElementAt(i).Tarif1, Month = indication.ElementAt(i).Month};
                ViewBag.Temp = " ";

               // listTotalInfo.Add(countes);
           // }

            return View(CounterInfo);
        }


        [HttpPost]
        public ActionResult IndicationTemp (int nomer, string month)
        {
                
            if (nomer == 0)
            {
                string mo = month;
                return Redirect(Url.Action("IndicationAllKioskiOneMonth", new {month=mo  }));
            }

            if (month == "")
            {
                int i = nomer;
                return Redirect(Url.Action("IndicationOneKioskAllMonth", new { id = nomer })); }
            else
            {

                return Redirect(Url.Action("IndicationOneKioskOneMonth", new { page = 1, nomer, month }));
            }

        }


        [HttpGet]
        public ActionResult IndicationAllKioskiOneMonth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndicationAllKioskiOneMonth(string month, int page = 1)
        {
            IEnumerable<AllCounter> listTotalInfo = db.GetAllCounters();
            int PageCom = 10;


            SchetchikViewModel CounterInfo = new SchetchikViewModel
            {
                AllCounters = listTotalInfo
                .Where(x=>x.Month.ToString()==month)
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = db.GetAllCounters().Count()
                }

            };
            viewTemp = 1;


            ViewBag.indicationKiosk = "One Month ALL Kiosk";

            return Redirect(Url.Action("IndicationMonth"));
        }


        [HttpGet]
        public ActionResult IndicationOneKioskAllMonth()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndicationOneKioskAllMonth(int nomer, int page=1)
        {
            IEnumerable<AllCounter> listTotalInfo = db.GetAllCounters();
            int PageCom = 10;


            SchetchikViewModel CounterInfo = new SchetchikViewModel
            {
                AllCounters = listTotalInfo
              .Where(x => x.NomerKioska==nomer.ToString())
              .Skip((page - 1) * PageCom)
              .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = db.GetAllCounters().Count()
                }
            };

            viewTemp = 2;

            ViewBag.indicationKiosk = "One Kiosk ALL Month";

            return Redirect(Url.Action("IndicationMonth"));
        }



        [HttpGet]
        public ActionResult IndicationOneKioskOneMonth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndicationOneKioskOneMonth(int nomer, string month, int page=1 )
        {
            IEnumerable<AllCounter> listTotalInfo = db.GetAllCounters();
            int PageCom = 10;


            SchetchikViewModel CounterInfo = new SchetchikViewModel
            {
                AllCounters = listTotalInfo
              .Where(x => x.NomerKioska == nomer.ToString()&& x.Month==month)
              .Skip((page - 1) * PageCom)
              .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = db.GetAllCounters().Count()
                }
            };

            return Redirect(Url.Action("IndicationMonth"));
        }




        [HttpGet]
        public ViewResult IndicationMonth(ActionResult action)
        {
            switch (viewTemp)
            {
                case 1: return View("IndicationAllKioskiOneMonth");
                case 2: return View("IndicationOneKioskAllMonth");
                default: return View("IndicationOneKioskOneMonth");
            }

            
        }


    }
}