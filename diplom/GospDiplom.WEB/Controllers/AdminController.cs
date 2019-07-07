using GospDiplom.BLL.DTO;
using GospDiplom.BLL.Infrastructure;
using GospDiplom.BLL.Interfaces;
using GospDiplom.BLL.Service;
using GospDiplom.WEB.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GospDiplom.Web.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
           // return View(UserManager.userDTO());
        }


        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        public ActionResult EditRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRole(string name, string role, string button)
        {
            
            bool z = button=="добавить"?true:false;
            if (ModelState.IsValid) { 
            OperationDetails operationDetails = await UserService.EditRole(/*model.UserName*/name, role,z);
                if (operationDetails.Succedeed) {

                    return RedirectToAction("Index", "Home");

                    //switch (UserService.FindByName(name).Role)
                    //{
                    //    case "admin":return View("Index", "Home");
                    //    case "moderator":return View("Index", "Home");
                    //    case "user":return View("Index", "Home");
                    //    case "kiosk":return View("IndexIndication", "IndicationInput");
                    //    default: return View("Login", "Account");
                    //}
                     }
                else

                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View();
        }



        private UserService UserManager
        {
            get
            {
                return null;
            }
        }
    }

   
}