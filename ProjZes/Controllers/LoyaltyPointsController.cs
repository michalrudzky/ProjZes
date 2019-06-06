using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjZes.Models;
using Microsoft.AspNet.Identity;
using ProjZes.Models.ViewModels;

namespace ProjZes.Controllers
{
    public class LoyaltyPointsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoyaltyPoints
        [Authorize]
        public ActionResult Index()
        {
            LoyaltyValues values = db.LoyaltyValues
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            if (User.IsInRole(Common.Constants.ManagerRole))
            {
                return View("IndexAdmin", values);
            }
            else
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);
                var points = user.Points;

                var viewModel = new LoyaltyPointsViewModel()
                {
                    Points = points,
                    Values = values
                };

                return View("Index", viewModel);
            }
        }

        // GET: LoyaltyPoints/SetValues
        [Authorize(Roles = Common.Constants.ManagerRole)]
        public ActionResult SetValues()
        {
            return View();
        }

        // POST: LoyaltyPoints/SetValues
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Common.Constants.ManagerRole)]
        public ActionResult SetValues([Bind(Include = "Id,Fuel,Lpg,Washing,WashingPlusWaxing")] LoyaltyValues loyaltyValues)
        {
            if (ModelState.IsValid)
            {
                db.LoyaltyValues.Add(loyaltyValues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loyaltyValues);
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
