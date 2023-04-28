using DiamondInventory.Models;
using DiamondInventory.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiamondInventory.Controllers
{
    public class DailyworkController : Controller
    {
        Dailyworkrepo Dailyworkrepo_ = new Dailyworkrepo();
        Workerrepo Workers = new Workerrepo();
        public ActionResult Index()
        {
            var mylist = Dailyworkrepo_.GetDailywork();

            return View(mylist);
        }

        public ActionResult Create()
        {
            Dailywork Dailywork = new Dailywork();
            var mylist = Workers.GetWorkers();
            List<SelectListItem> mylist_ = new List<SelectListItem>();
            foreach (var item in mylist)
            {

                mylist_.Add(new SelectListItem
                {
                    Text = item.WorkerId.ToString(),
                    Value = item.Workername
                });
            }
            ViewBag.Workers = mylist_;

            return View(Dailywork);
            
        }

        [HttpPost]
        public ActionResult Create(Dailywork D)
        {
                                  
            D.DailyworkID = Guid.NewGuid();
            Dailyworkrepo_.Add(D); 
            return RedirectToAction("Index");


        }
        public ActionResult Edit(Guid wid)
        {
            //Dailywork Dailywork = new Dailywork();
            var mylist = Workers.GetWorkers();
            List<SelectListItem> mylist_ = new List<SelectListItem>();
            foreach (var item in mylist)
            {

                mylist_.Add(new SelectListItem
                {
                    Text = item.WorkerId.ToString(),
                    Value = item.Workername
                });
            }
            ViewBag.Workers = mylist_;

            var mylist_1 = Dailyworkrepo_.Edit(wid);
            return View(mylist_1);
        }
        [HttpPost]
        public ActionResult Edit(Dailywork D)
        {

            Dailyworkrepo_.update(D);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid wid)
        {
            var mylist = Dailyworkrepo_.Edit(wid);
            return View(mylist);
        }
        [HttpPost]
        public ActionResult Delete(Dailywork D)
        {

            Boolean ischeak = Dailyworkrepo_.Delete(D.DailyworkID);
            return RedirectToAction("Index");
        }
    }


}
    
