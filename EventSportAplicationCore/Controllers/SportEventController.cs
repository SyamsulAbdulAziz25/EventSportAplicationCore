using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventSportAplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sport.BussinesLogicLayer;
using Sport.Core;
using Sport.Core.Output;

namespace EventSportAplicationCore.Controllers
{
    public class SportEventController : Controller
    {
        private readonly ISportEventBussinesLayer sportEventBussinesLayer;
        private readonly IMapper mapper;
        public SportEventController(ISportEventBussinesLayer sportEventBussinesLayer,IMapper mapper)
        {
            this.sportEventBussinesLayer = sportEventBussinesLayer;
            this.mapper = mapper;
        }

        // GET: SportEvent
        public ActionResult Index()
        {
            return View(sportEventBussinesLayer.GetActiveAllEvents());
        }

        // GET: SportEvent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SportEvent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SportEvent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelEvent ev)
        {

            try
            {
                // TODO: Add insert logic here

                if (ev.Date < DateTime.Now)
                {

                    ModelState.AddModelError("Date", "Must be grate than today");
                    return View();
                }
                else
                {
                    //SportEventOutput dd = new SportEventOutput();
                    Event data = mapper.Map<Event>(ev);
                    sportEventBussinesLayer.InsertUser(data);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: SportEvent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SportEvent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SportEvent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SportEvent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}