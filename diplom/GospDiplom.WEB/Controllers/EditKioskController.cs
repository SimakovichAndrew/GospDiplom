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
    [Authorize(Roles = "admin")]
    public class EditKioskController : Controller
    {
        IProcedureService orderService;
        public int PageCom = 25;

        public EditKioskController(IProcedureService serv)
        {
            orderService = serv;
        }

        // GET: Index
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult EditKiosk(string nomer, int page = 1)
        {
            KioskDTO kiosk = orderService.GetInfokiosk(nomer);
            string orgName = orderService.GetOrganization(orderService.GetKiosks().Where(x => x.Nomer == nomer).First().OrganizationId).OrgName;
            SelectList listName = new SelectList(orderService.GetOrganizations(), "OrgName");
            ViewBag.OrgNames = orgName;
            //OrganizationId добавить метод в бизнес логику для добавления киоска в контрагента
            IEnumerable<AllTable> tableKioski = orderService.GetAllKioski();
            KioskViewModel editKiosk = new KioskViewModel
            {
                OrgName = orgName,
                Adress = kiosk.Adress,
                Area = kiosk.Area,
                Arenda = kiosk.Arenda,
                Town = kiosk.Town,
                ModelKioska = kiosk.ModelKioska,
                Nomer = kiosk.Nomer,
                OrganizationId = (int)kiosk.OrganizationId,
                KioskId = kiosk.KioskId
            };
            return View(editKiosk);
        }

        [HttpPost]
        public ActionResult EditKiosk(EditKioskModels kiosk)
        {
            KioskDTO editKiosk = new KioskDTO
            {
                ModelKioska = "Редактируется"
            };
           orderService.EditKiosk(editKiosk);
            ViewBag.TempKiosk = "TEMP";

            return View("Index", "Home");

        }

        //[HttpGet]
        public ActionResult KioskUpDate(int page = 1)
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
            RedirectToAction("Index", "Home", listInput);
            return View("Index");
        }

        //[HttpGet]
        public ActionResult CounterUpDate(int page = 1)
        {
            orderService.UpdateCounters();
            IEnumerable<AllCounter> tableCounter = orderService.GetAllCounters();
            ViewBag.totalInfo = tableCounter;
            InputViewModels listInput = new InputViewModels
            {
               AllCounters = tableCounter
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = orderService.GetAllCounters().Count()
                }

            };

            
            RedirectToAction("Index", "Home", listInput);
            
            return View("Index");
        }

        //[HttpGet]
        public ActionResult IndicatUpDate(int page = 1)
        {
            orderService.UpdateIndicat();
          //  IEnumerable<IndicationDTO> indicationDTOs = orderService.GetIndications();
          IEnumerable<AllCounter> tableCounter = orderService.GetAllCounters();
            ViewBag.totalInfo = tableCounter;
            InputViewModels listInput = new InputViewModels
            {
                AllCounters = tableCounter
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = orderService.GetAllCounters().Count()
                }

            };


            RedirectToAction("Index", "Home", listInput);

            return View("Index");
        }



    }
}