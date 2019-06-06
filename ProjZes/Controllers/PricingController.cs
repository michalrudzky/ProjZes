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

            return View(viewModel);
        }

        // GET: Pricing/UpdateFuelPrice
        [Authorize(Roles = Common.Constants.ManagerRole)]
        public ActionResult UpdateFuelPrice()
        {
            return View();
        }

        // POST: Pricing/UpdateFuelPrice
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Common.Constants.ManagerRole)]
        public ActionResult UpdateFuelPrice([Bind(Include = "Id,Pb95,Pb98,Diesel,Lpg")] FuelPricing fuelPricing)
        {
            if (ModelState.IsValid)
            {
                db.FuelPricing.Add(fuelPricing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuelPricing);
        }

        // GET: Pricing/UpdateCarWashPrice
        [Authorize(Roles = Common.Constants.ManagerRole)]
        public ActionResult UpdateCarWashPrice()
        {
            return View();
        }

        // POST: Pricing/UpdateCarWashPrice
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Common.Constants.ManagerRole)]
        public ActionResult UpdateCarWashPrice([Bind(Include = "Id,Washing,Waxing,WashingAndWaxing,Polishing,WashingAndWaxingAndPolishing")] CarWashPricing carWashPricing)
        {
            if (ModelState.IsValid)
            {
                db.CarWashPricing.Add(carWashPricing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carWashPricing);
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
