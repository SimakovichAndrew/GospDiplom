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
            KioskViewModel editKiosk = new KioskViewModel {
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

            ViewBag.TempKiosk = "TEMP";

            return View("Login");
        }
    }
}