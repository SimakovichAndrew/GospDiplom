using GospDiplom.BLL.DTO;
using GospDiplom.BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospDiplom.WEB.Controllers
{
    public class IndicationInputController : Controller
    {
        private UserDTO CurrentUser
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>().FindByName(User.Identity.Name);

            }
        }
        IProcedureService db;
        public IndicationInputController(IProcedureService orderService)
        {
            db = orderService;
        }


        // GET: IndicationInput
        public ActionResult IndexIndication()
        {
            ViewBag.UserName = CurrentUser.LastName;
            ViewBag.UserAdress = CurrentUser.Address;
            int dateTime = DateTime.Now.Hour;
            switch (dateTime)
            {
                case 1: case 2: case 3: case 4: case 5: case 22: case 23: ViewBag.Greeting = "Доброй ночи"; break;
                case 6: case 7: case 8: case 9: case 10: ViewBag.Greeting = "Доброе утро"; break;
                case 11: case 12: case 13: case 14: case 15: case 16: case 17: ViewBag.Greeting = "Добрый день"; break;
                case 18: case 19: case 20: case 21: ViewBag.Greeting = "Добрый вечер"; break;
            }

            return View("IndexIndication");
        }

        // GET: IndicationInput/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndicationInput/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndicationInput/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            ViewBag.Error = "";
            try
            {
                // TODO: Add insert logic here
                db.CreateIndication(CurrentUser.Address, Convert.ToDouble(collection.GetValue("tarif1").AttemptedValue), Convert.ToDouble(collection.GetValue("tarif2").AttemptedValue));




                ViewBag.Tarif = collection.GetValue("tarif1").AttemptedValue;

                //return RedirectToAction("IndexIndication");
                return View("_IndicationNew");
            }
            catch
            {
                ViewBag.Error = "Заполняется только цифрами, знак разделения -запятая.";
                return View("IndexIndication");
            }
        }

        // GET: IndicationInput/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndicationInput/Edit/5
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

        // GET: IndicationInput/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndicationInput/Delete/5
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
