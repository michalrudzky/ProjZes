using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjZes.Models;
using ProjZes.Models.ViewModels;

namespace ProjZes.Controllers
{
    public class PricingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pricing
        public ActionResult Index()
        {
            var fuel = db.FuelPricing.OrderByDescending(x => x.Id).FirstOrDefault();
            var carWash = db.CarWashPricing.OrderByDescending(x => x.Id).FirstOrDefault();

            var viewModel = new PricingViewModel()
            {
                Fuel = fuel,
                CarWash = carWash
            };

            //return View(db.FuelPricing.ToList());
            return View(viewModel);
        }

        // GET: Pricing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelPricing fuelPricing = db.FuelPricing.Find(id);
            if (fuelPricing == null)
            {
                return HttpNotFound();
            }
            return View(fuelPricing);
        }

        // GET: Pricing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pricing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pb95,Pb98,Diesel,Lpg")] FuelPricing fuelPricing)
        {
            if (ModelState.IsValid)
            {
                db.FuelPricing.Add(fuelPricing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuelPricing);
        }

        // GET: Pricing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelPricing fuelPricing = db.FuelPricing.Find(id);
            if (fuelPricing == null)
            {
                return HttpNotFound();
            }
            return View(fuelPricing);
        }

        // POST: Pricing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pb95,Pb98,Diesel,Lpg")] FuelPricing fuelPricing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuelPricing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuelPricing);
        }

        // GET: Pricing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelPricing fuelPricing = db.FuelPricing.Find(id);
            if (fuelPricing == null)
            {
                return HttpNotFound();
            }
            return View(fuelPricing);
        }

        // POST: Pricing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FuelPricing fuelPricing = db.FuelPricing.Find(id);
            db.FuelPricing.Remove(fuelPricing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
