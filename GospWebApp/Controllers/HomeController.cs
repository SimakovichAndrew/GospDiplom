using GospWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GospWebApp.Controllers
{
    public class HomeController : Controller
    {
        //  
        // GET: /Home/  
        ServiceReference1.GospServiceClient ur = new ServiceReference1.GospServiceClient();
        public ActionResult Index()
        {
            List<User> lstRecord = new List<User>();

            var lst = ur.GetAllUser();

            foreach (var item in lst)
            {
                User usr = new User();
                usr.Id = item.IdKiosk;
                usr.Nomer = item.nomer;
                usr.Model = item.model;
                lstRecord.Add(usr);

            }


            return View(lstRecord);
        }


        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(User mdl)
        {

            User usr = new User();
            usr.Nomer = mdl.Nomer;
            usr.Model = mdl.Model;
            ur.AddUser(usr.Nomer, usr.Model);
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Delete(int id)
        {
            int retval = ur.DeleteUserById(id);
            if (retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var lst = ur.GetAllUserById(id);
            User usr = new User();
            usr.Id = lst.IdKiosk;
            usr.Nomer = lst.nomer;
            usr.Model = lst.model;
            return View(usr);

        }
        [HttpPost]
        public ActionResult Edit(User mdl)
        {
            User usr = new User();
            usr.Id = mdl.Id;
            usr.Nomer = mdl.Nomer;
            usr.Model = mdl.Model;


            int Retval = ur.UpdateUser(usr.Id, usr.Nomer, usr.Model);
            if (Retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}