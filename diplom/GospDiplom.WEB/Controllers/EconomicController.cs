using AutoMapper;
using GospDiplom.BLL.DTO;
using GospDiplom.BLL.Interfaces;
using GospDiplom.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospDiplom.WEB.Controllers
{
    public class EconomicController : Controller
    {
        IProcedureService db;
        public EconomicController( IProcedureService context)
        {
            db = context;
        }


        // GET: Economic
        [HttpGet]
        public ActionResult Index()
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

#pragma warning disable CS0219 // Переменной "total" присвоено значение, но оно ни разу не использовано.
            double total = 0;
#pragma warning restore CS0219 // Переменной "total" присвоено значение, но оно ни разу не использовано.

            List<InputViewModels> listTotalInfo = new List<InputViewModels>();
            for (int i = 0; i < db.GetCounters().Count(); i++)
            {
                listTotalInfo.Add(new InputViewModels
                {

                    //Counetr = db.GetCounters().ElementAt(i),
                    //Kiosk = db.GetKiosks().Where(x => x.KioskId == db.GetCounters().ElementAt(i).KioskId).First(),
                    //Indication = db.GetIndications().Where(y => y.SchetchikId == db.GetCounters().ElementAt(i).SchetchikId).First(),
                    //OrgName = db.GetIndications().Where(y => y.SchetchikId == db.GetCounters().ElementAt(i).SchetchikId).First().Month.ToString("MMMM")
                });
            }

            return View(listTotalInfo);
        }

        // GET: Economic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Economic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Economic/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Economic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Economic/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Economic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Economic/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
