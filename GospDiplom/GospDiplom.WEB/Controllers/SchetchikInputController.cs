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

            IEnumerable<SchetchikDTO> counter = db.GetCounters();
            double total = 0;
            ViewBag.totalMessage = counter;

            IndicationViewModel count = new IndicationViewModel
            {
                // Retrieve the numbers that the user entered.
                Tarif1 = db.GetIndication(3).Tarif1,
                Tarif2 = db.GetIndication(3).Tarif2
            };
            // Convert the entered strings into integers numbers and add.
            total = count.Tarif1 + count.Tarif2; //num1.AsInt() + num2.AsInt();
                    ViewBag.Message = "Сумма = " + total;
           
            return View(count);
        }
    }
}