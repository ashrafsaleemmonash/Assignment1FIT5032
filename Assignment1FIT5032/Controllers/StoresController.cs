using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1FIT5032.Models;

namespace Assignment1FIT5032.Controllers
{
    public class StoresController : Controller
    {
        private StoreRatingContainer db = new StoreRatingContainer();

        // GET: Stores
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Index()
        {
            var storeList = db.Stores.ToList();
            var ratingList = db.Ratings.ToList();
            var query = from store in storeList
                        join rating in ratingList
                        on new { id = store.Id }
                        equals new { id = rating.Store_Id } into allColumn
                        select new { Id = store.Id, Street = store.Street, Suburb = store.Suburb, State = store.State, Postal_Code = store.Postal_Code, Operating_Hours = store.Operating_Hours, storeRatingsAvg = allColumn.Average(e => e.Store_Rating)};
            var ratingAverage = new List<RatingAverage>();
            foreach(var q in query)
            {
                ratingAverage.Add(new RatingAverage() { 
                    Id = q.Id, 
                    averageRating = (double)Math.Round((decimal)q.storeRatingsAvg, 2), 
                    Street = q.Street, 
                    Suburb = q.Suburb, 
                    State = q.State ,
                    Postal_Code = q.Postal_Code, 
                    Operating_Hours = q.Operating_Hours });
            }
            return View(ratingAverage);
        }
        //IEnumerable<int, string, string, int, string, double>
        // GET: Stores/Details/5
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        [Authorize(Roles = "Admin")] // Allowing Only Admin
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")] // Allowing Only Admin
        public ActionResult Create([Bind(Include = "Id,Street,Suburb,State,Postal_Code,Operating_Hours")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Stores/Edit/5
        [Authorize(Roles = "Admin")] // Allowing Only Admin
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")] // Allowing Only Admin
        public ActionResult Edit([Bind(Include = "Id,Street,Suburb,State,Postal_Code,Operating_Hours")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        [Authorize(Roles = "Admin")] // Allowing Only Admin
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")] // Allowing Only Admin
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
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
