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
    public class BookingsController : Controller
    {
        private BookingContainer db = new BookingContainer();

        //public List<Booking> bookings = new List<Booking>();
        // GET: Bookings
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.AspNetUser);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

         // Function to get book list and also to ensure a string format of the book dates are met
        public void GetBook()
        {
            var bookeds = db.Bookings.ToList();
            List<string> bookings = new List<string>();
            foreach (var b in bookeds)
            {
                bookings.Add(b.Date.ToString("yyyy-MM-dd"));
            }
            ViewBag.bookings = bookings;
        }

        // GET: Bookings/Create
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Create()
        {
            GetBook();
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Create([Bind(Include = "Id,Date,User_Id")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                //To get the user who is booking ID
                booking.User_Id = User.Identity.GetUserId();
                //Getting the dates from the database
                var dates = db.Bookings.ToList();
                //Looping through each date in the database
                foreach(var d in dates)
                {
                    //If the date & the user entered date matches do this:
                    if(d.Date == booking.Date)
                    {
                        // To reset the GetBook to ensure a re-render of the booked dates are made
                        GetBook();
                        // Adding a model error to say what happens if an error occurs (Date book error handling)
                        ModelState.AddModelError(nameof(Booking.Date), "Date has already been booked.");
                        // Return back the view
                        return View(booking);
                    } 
                }
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", booking.User_Id);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        [Authorize(Roles = "Admin")] // Allowing Only Admin
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", booking.User_Id);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderator")] // Allowing Only Admin
        public ActionResult Edit([Bind(Include = "Id,Date,User_Id")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", booking.User_Id);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Moderator,Default")] // Allowing Only Logined In Accounts
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
