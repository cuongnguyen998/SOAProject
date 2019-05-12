using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SOA.WebApi.Models;
namespace SOA.WebApi.Controllers
{
    public class AbsenceTracksController : Controller
    {
        // GET: AbsenceTracks
        public ActionResult Index(HttpPostedFileBase file)
        {
            return View();
        }

        // GET: AbsenceTracks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AbsenceTracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbsenceTracks/Create
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

        // GET: AbsenceTracks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AbsenceTracks/Edit/5
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

        // GET: AbsenceTracks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AbsenceTracks/Delete/5
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
