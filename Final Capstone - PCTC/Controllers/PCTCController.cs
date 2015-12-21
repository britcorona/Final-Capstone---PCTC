using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Capstone___PCTC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Final_Capstone___PCTC.Controllers
{
    public class PCTCController : Controller
    {
        public PCTCRepository Repository { get; set; }

        public PCTCController() : base()
        {
            Repository = new PCTCRepository();
        }

        // GET: PCTC
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UsersTCFeed()
        {
            string user_id = User.Identity.GetUserId();
            PCTCUser me = Repository.GetAllUsers().Where(u => u.RealUser.Id == user_id).Single();
            List<TimeCapsule> list_of_tcs = Repository.GetUsersTCs(me);
            return View(list_of_tcs);
        }

        // GET: PCTC/Details/5
        public ActionResult Details(int id)
        {
            //return View();

            List<TimeCapsule> my_tcs = Repository.GetAllTCs();
            return View(my_tcs);
        }

        // GET: PCTC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PCTC/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PCTC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PCTC/Edit/5
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

        // GET: PCTC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PCTC/Delete/5
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
