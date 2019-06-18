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
        // int  viewTemp = 0;

        public SchetchikInputController(IProcedureService orderService)
        {
            db = orderService;
        }

        // GET: Temp
        [HttpGet]
        public ActionResult Index(int page = 1)
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
            int PageCom = 5;
            ViewBag.Temp = 0;//индикация для partialView index SchetchikInput

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


            // listTotalInfo.Add(countes);
            // }

            return View(CounterInfo);
        }


        [HttpPost]
        public ActionResult IndicationTemp(int nomer, string month, string checkSort)
        {
            ViewBag.Sort = checkSort;

            if (nomer == 0 && month != "")
            {
                //string mo = month;
                return IndicationAllKioskiOneMonth(month);
            }
            else
            {
                if (month == "" && nomer != 0)
                {
                    int i = nomer;
                    return IndicationOneKioskAllMonth(nomer);
                }
                else
                {
                    if (month != "" && nomer != 0)
                        return IndicationOneKioskOneMonth(nomer, month);
                    else
                    {
                        SchetchikViewModel schetchikViewModel = new SchetchikViewModel()
                        {
                            AllCounters = new List<AllCounter>()
                        };

                        string sort = ViewBag.Sort;
                        switch (sort)
                        {
                            case "2": schetchikViewModel.AllCounters.OrderBy(y => y.Date); break;
                            case "3": schetchikViewModel.AllCounters.OrderBy(y => (y.Tarif2 - y.Tarif1)); break;
                            default: schetchikViewModel.AllCounters.OrderBy(y => y.NomerKioska); break;
                        }

                        return IndicationMonth(schetchikViewModel);
                    }
                }
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
            int PageCom = 5;
            ViewBag.Month = month;

            SchetchikViewModel CounterInfo = new SchetchikViewModel
            {
                AllCounters = listTotalInfo
                .Where(x => x.Month == month)
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = db.GetAllCounters().Count()
                }

            };
            // viewTemp = 1;


            ViewBag.indicationKiosk = "One Month ALL Kiosk";

            return IndicationMonth(CounterInfo);
        }


        [HttpGet]
        public ActionResult IndicationOneKioskAllMonth()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndicationOneKioskAllMonth(int nomer, int page = 1)
        {

            IEnumerable<AllCounter> listTotalInfo = db.GetAllCounters();
            int PageCom = 10;
            ViewBag.Nomer = nomer;

            SchetchikViewModel CounterInfo = new SchetchikViewModel
            {
                AllCounters = listTotalInfo
              .Where(x => x.NomerKioska == nomer.ToString())
              .Skip((page - 1) * PageCom)
              .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = db.GetAllCounters().Count()
                }
            };
            ViewBag.indicationKiosk = "One Kiosk ALL Month";

            string sort = ViewBag.Sort;
            switch (sort)
            {
                case "2": CounterInfo.AllCounters.OrderBy(y => y.Date); break;
                case "3": CounterInfo.AllCounters.OrderBy(y => (y.Tarif2 - y.Tarif1)); break;
                default: CounterInfo.AllCounters.OrderBy(y => y.NomerKioska); break;
            }

            return IndicationMonth(CounterInfo);
        }



        [HttpGet]
        public ActionResult IndicationOneKioskOneMonth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndicationOneKioskOneMonth(int nomer, string month, int page = 1)
        {
            IEnumerable<AllCounter> listTotalInfo = db.GetAllCounters();
            int PageCom = 10;


            SchetchikViewModel CounterInfo = new SchetchikViewModel
            {
                AllCounters = listTotalInfo
              .Where(x => x.NomerKioska == nomer.ToString() && x.Month == month)
              .Skip((page - 1) * PageCom)
              .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = db.GetAllCounters().Count()
                }
            };
            ViewBag.Nomer = nomer;
            ViewBag.Month = month;
            return IndicationMonth(CounterInfo);
        }




        [HttpGet]
        public ViewResult IndicationMonth(SchetchikViewModel schetchikViewModel, int page = 1)
        {
            // viewTemp = 3;
            ViewBag.Temp = 1;//индикация для partialView index SchetchikInput
            SchetchikViewModel CounterInfo=null;
            List<AllCounter> x = null;
            

            if (schetchikViewModel.AllCounters.Count() != 0)
            {
                CounterInfo = schetchikViewModel;
               // x = schetchikViewModel.AllCounters.ToList();
                //ViewData["SchetchikAllCounters"] = x;
            }
            else
            {
                IEnumerable<AllCounter> listTotalInfo = db.GetAllCounters();
                int PageCom = 10;

                CounterInfo = new SchetchikViewModel
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

               // x = CounterInfo.AllCounters.OrderBy(y=>y.Date).ToList();

                //ViewData["SchetchikAllCounters"] = x;
            }



            //string sort = ViewBag.Sort;
            //switch (sort)
            //{
            //    case "2": x = CounterInfo.AllCounters.OrderBy(y => y.Date).ToList(); break;
            //    case "3": x = CounterInfo.AllCounters.OrderBy(y => (y.Tarif1+y.Tarif2)).ToList(); break;
            //    default: x = CounterInfo.AllCounters.OrderBy(y => y.NomerKioska).ToList(); break;
            //}
            ViewData["SchetchikAllCounters"] = CounterInfo.SortCounter(ViewBag.Sort);

            return View("IndicationMonth");
        }


    }
}