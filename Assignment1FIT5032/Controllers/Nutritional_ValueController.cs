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
    public class Nutritional_ValueController : Controller
    {
        private NutritionableContainer db = new NutritionableContainer();

        // GET: Nutritional_Value
        [Authorize(Roles = "Admin,Default")]
        public ActionResult Index()
        {
            return View(db.Nutritional_Value.ToList());
        }

        // GET: Nutritional_Value/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nutritional_Value nutritional_Value = db.Nutritional_Value.Find(id);
            if (nutritional_Value == null)
            {
                return HttpNotFound();
            }
            return View(nutritional_Value);
        }

        // GET: Nutritional_Value/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nutritional_Value/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Food,Serving_Gram,Calories,Calories_From_Fat,Total_Fat_Gram,Total_Fat_Daily_Value_By_Precentage,Sodium_Gram,Sodium_Daily_Value_By_Precentage,Potassium_Gram,Potassium_Daily_Value_By_Precentage,Total_Carbo_Hydrate_Gram,Total_Carbo_Hydrate_Daily_Value_By_Precentage,Dietary_Fiber_Gram,Dietary_Fiber_Daily_Value_By_Precentage,Sugar_Gram,Protein_Gram,Vitamin_A_Daily_Value_By_Precentage,Vitamin_C_Daily_Value_By_Precentage,Calcium_Daily_Value_By_Precentage,Iron_Daily_Value_By_Precentage,Saturated_Daily_Value_By_Precentage,Saturated_Milligram,Chole_Sterol_Daily_Value_By_Precentage,Chole_Sterol_Milligram,Food_Type,Date")] Nutritional_Value nutritional_Value)
        {
            if (ModelState.IsValid)
            {
                db.Nutritional_Value.Add(nutritional_Value);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nutritional_Value);
        }

        // GET: Nutritional_Value/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nutritional_Value nutritional_Value = db.Nutritional_Value.Find(id);
            if (nutritional_Value == null)
            {
                return HttpNotFound();
            }
            return View(nutritional_Value);
        }

        // POST: Nutritional_Value/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Food,Serving_Gram,Calories,Calories_From_Fat,Total_Fat_Gram,Total_Fat_Daily_Value_By_Precentage,Sodium_Gram,Sodium_Daily_Value_By_Precentage,Potassium_Gram,Potassium_Daily_Value_By_Precentage,Total_Carbo_Hydrate_Gram,Total_Carbo_Hydrate_Daily_Value_By_Precentage,Dietary_Fiber_Gram,Dietary_Fiber_Daily_Value_By_Precentage,Sugar_Gram,Protein_Gram,Vitamin_A_Daily_Value_By_Precentage,Vitamin_C_Daily_Value_By_Precentage,Calcium_Daily_Value_By_Precentage,Iron_Daily_Value_By_Precentage,Saturated_Daily_Value_By_Precentage,Saturated_Milligram,Chole_Sterol_Daily_Value_By_Precentage,Chole_Sterol_Milligram,Food_Type,Date")] Nutritional_Value nutritional_Value)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nutritional_Value).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nutritional_Value);
        }

        // GET: Nutritional_Value/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nutritional_Value nutritional_Value = db.Nutritional_Value.Find(id);
            if (nutritional_Value == null)
            {
                return HttpNotFound();
            }
            return View(nutritional_Value);
        }

        // POST: Nutritional_Value/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(long id)
        {
            Nutritional_Value nutritional_Value = db.Nutritional_Value.Find(id);
            db.Nutritional_Value.Remove(nutritional_Value);
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
