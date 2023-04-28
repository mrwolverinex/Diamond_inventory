using DiamondInventory.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiamondInventory.Models;

namespace DiamondInventory.Controllers
{
    public class WorkerController : Controller
    {
        Workerrepo Workers = new Workerrepo();
        Workertyperepo _Workertyperepo = new Workertyperepo();
        public ActionResult Index()
        {
            var mylist = Workers.GetWorkers();
            return View(mylist);
        }

        public ActionResult Create()
        {
            Worker worker = new Worker();
            var mylist = _Workertyperepo.GetWorkerType();
            List<SelectListItem> mylist_ = new List<SelectListItem>();
            foreach (var item in mylist)
            {

                mylist_.Add(new SelectListItem
                {
                    Text = item.TypeName,
                    Value = item.TypeName
                });
            }
            ViewBag.Workers = mylist_;

            return View(worker);
        }

        [HttpPost]
        public ActionResult Create(Worker W)
        {
            W.WorkerId = Guid.NewGuid();
            Workers.Add(W);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Guid wid)
        {
            Worker worker = new Worker();
            var mylist = _Workertyperepo.GetWorkerType();
            List<SelectListItem> mylist_ = new List<SelectListItem>();
            foreach (var item in mylist)
            {

                mylist_.Add(new SelectListItem
                {
                    Text = item.TypeName,
                    Value = item.TypeName
                });
            }
            ViewBag.Workers = mylist_;

            var mylist_1 = Workers.Edit(wid);
            return View(mylist_1);

        }
        [HttpPost]
        public ActionResult Edit(Worker W)
        {

            Workers.update(W);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid wid)
        {
            var mylist = Workers.Edit(wid);
            return View(mylist);
        }
        [HttpPost]
        public ActionResult Delete(Worker W)
        {

            Boolean ischeck = Workers.Delete(W.WorkerId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetPrice(string Worktype)
        {
            decimal myprice = Workers.Getprice(Worktype);
            return Json(myprice, JsonRequestBehavior.AllowGet);
        }
    }
}

