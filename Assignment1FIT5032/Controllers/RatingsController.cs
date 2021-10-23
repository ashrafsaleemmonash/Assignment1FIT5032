using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1FIT5032.Models;
using Microsoft.AspNet.Identity;

namespace Assignment1FIT5032.Controllers
{
    public class RatingsController : Controller
    {
        private StoreRatingContainer db = new StoreRatingContainer();
        // GET: Ratings
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var rating = db.Ratings.Where(s => s.User_Id ==userId).ToList();
            return View(rating);
        }

        // GET: Ratings/Details/5
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // GET: Ratings/Create
        [Authorize]
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Create(int? id)
        {
            if(id != null)
            {
                Rating rating = new Rating();
                rating.Store_Id = (int)id;
                rating.User_Id = User.Identity.GetUserId();
                return View(rating);
            }
            else
            {
                return View();
            }
        }

        //public ActionResult CreateWithId(int id)
        //{
        //    Rating rating = new Rating();
        //    rating.Store_Id = id;
        //    return View(rating); 
        //}

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Create([Bind(Include = "Id,Store_Rating,Comment,User_Id,Store_Id")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Ratings.Add(rating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rating);
        }

        // GET: Ratings/Edit/5
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Edit([Bind(Include = "Id,Store_Rating,Comment,User_Id,Store_Id")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rating);
        }

        // GET: Ratings/Delete/5
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult DeleteConfirmed(int id)
        {
            Rating rating = db.Ratings.Find(id);
            db.Ratings.Remove(rating);
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
