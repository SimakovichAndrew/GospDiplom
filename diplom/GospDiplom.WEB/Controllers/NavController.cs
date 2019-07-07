using GospDiplom.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospDiplom.WEB.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        ProcedureService recordService;

        public NavController(ProcedureService repo)
        {
            recordService = repo;
        }
        
        public PartialViewResult Menu(string town = null)
        {
            ViewBag.SelectTown= town;
            IEnumerable<string> towns = recordService.GetKiosks()
             .Select(x => x.Town)
             .Distinct()
             .OrderBy(x => x);


            return PartialView(towns);
        }

    }
}