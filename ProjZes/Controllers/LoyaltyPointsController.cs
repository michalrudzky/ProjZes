﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjZes.Models;
using ProjZes.Models.ViewModels;
using Microsoft.AspNet.Identity;

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

            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var points = user.Points;

            var viewModel = new LoyaltyPointsViewModel()
            {
                Points = points,
                Values = values
            };

            return View(viewModel);
        }

        public ActionResult IndexAdmin()
        {
            LoyaltyValues values = db.LoyaltyValues
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            return View(values);
        }

        // GET: LoyaltyPoints/SetValues
        public ActionResult SetValues()
        {
            return View();
        }

        // POST: LoyaltyPoints/SetValues
        [HttpPost]
        [ValidateAntiForgeryToken]
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
