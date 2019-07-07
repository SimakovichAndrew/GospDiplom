using GospDiplom.BLL.DTO;
using GospDiplom.BLL.Interfaces;
using GospDiplom.BLL.Service;
using GospDiplom.WEB.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GospDiplom.WEB.Controllers
{
    public class TownController : Controller
    {
        private UserDTO CurrentUser
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>().FindByName(User.Identity.Name);

            }
        }

        ProcedureService repository;
       private int SelectTownId;
        private string topicname;

        public int PageCom = 25;
        public TownController(ProcedureService comentRepository)
        {
            this.repository = comentRepository;
           
        }

        public ActionResult SelectTown(string town, int page = 1/*int topicid*/)
        {
            
            Session["town"] = town;
            //SelectTownId = repository.GetTopicName(town).KioskId;
           // town = (string)Session["town"];
            InputViewModels model = new InputViewModels
            {
                AllKioski = repository.GetAllKioski()
                .Where(p => town == p.Gorod/* || p.KioskId == SelectTownId*/)
                .OrderBy(p => p.Gorod)
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = town == null ?
                 repository.GetKiosks().Count() :
                 repository.GetKiosks().Where(e => e.Town == town).Count()
                }
            };

            ViewBag.SelectTown = repository.GetKiosks().Where(x => x.Town == town).First().Town;
            // return View(model);
            return RedirectToAction("Town");
        }



        [Authorize]

        public ViewResult Town(/*TownListViewModel modelstringstring town, */int page = 1)
        {
            if (Session["town"] == null)
                Session["town"] = repository.GetKiosks().First().Town;
            string town = (string)Session["town"];
            SelectTownId = repository.GetKiosks().Where(x=>x.Town==town).First().KioskId;

            InputViewModels model = new InputViewModels
            {
                AllKioski = repository.GetAllKioski()
                .Where(p => town == p.Gorod/* || p.KioskId == SelectTownId*/)
                .OrderBy(p => p.Gorod)
                .Skip((page - 1) * PageCom)
                .Take(PageCom),
                PagingInfoCom = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageCom,
                    TotalItems = town == null ?
                 repository.GetKiosks().Count() :
                 repository.GetKiosks().Where(e => e.Town == town).Count()
                }
            };

            ViewBag.SelectTown = repository.GetKiosks().Where(x=>x.Town==town).First().Town;


            return View(model);
        }
        //_______________________________________________________________________________



        [HttpGet]
        public ActionResult _Send()
        {
            return View();
        }



    [HttpPost]
        public ActionResult _Send(TownListViewModel com, string returnUrl, int page = 1)
        {
            string town = com.CurrentTownName;
           // SelectTownId = repository.GetKiosk.topicname;
            //repository.(com.Content, SelectTownId, User.Identity.LastName);
            //TownListViewModel model = new TownListViewModel
            //{
            //    KioskId = SelectTownId,
            //    GetComments = repository.GetComments()
            //    .Where(p => town == null || p.ComTopicId == SelectTownId)
            //    .OrderBy(p => p.CommentId)
            //    .Skip((page - 1) * PageCom)
            //    .Take(PageCom),
            //    PagingInfoCom = new PagingInfo
            //    {
            //        CurrentPage = page,
            //        ItemsPerPage = PageCom,
            //        TotalItems = town == null ?
            //     repository.GetComments().Count() :
            //     repository.GetComments().Where(e => e.ComTopicName == town).Count()
            //    },
            //    CurrentTopicName = town,
            //    Autor = User.Identity.LastName
            //};

           // ViewBag.SelectTopicName = repository.GetTopicName(town).TopicName;

            // var coment = repository.GetSchetchiks();
            //return View(model);
             return RedirectToAction ("Town", "Town" );
        }
       
    }
}