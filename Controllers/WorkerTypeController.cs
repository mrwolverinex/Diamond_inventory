using DiamondInventory.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiamondInventory.Models;

namespace DiamondInventory.Controllers
{
    public class WorkerTypeController : Controller
    {
        Workertyperepo _Workertype = new Workertyperepo();

        public ActionResult Index()
        {
            var mylist = _Workertype.GetWorkerType();

            return View(mylist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorkerType W)
        {
            W.WorkTypeID = Guid.NewGuid();
            _Workertype.Add(W);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(Guid wid)
        {

            var mylist = _Workertype.Edit(wid);
            return View(mylist);

        }
        [HttpPost]
        public ActionResult Edit(WorkerType W)
        {

            _Workertype.update(W);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid wid)
        {
            var mylist = _Workertype.Edit(wid);
            return View(mylist);
        }
        [HttpPost]
        public ActionResult Delete(WorkerType W)
        {

           Boolean ischeak= _Workertype.Delete(W.WorkTypeID);
            return RedirectToAction("Index");
        }
    }
}