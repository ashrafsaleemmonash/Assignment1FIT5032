using Assignment1FIT5032.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Assignment1FIT5032.Controllers
{
    public class GraphController : Controller
    {
        private NutritionableContainer db = new NutritionableContainer();
        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            // Initialization.  


                // Loading.  
                var nutritional = db.Nutritional_Value.ToList();

                // Setting.  
                var graphData = nutritional.GroupBy(r => new
                {
                    r.Food,
                    r.Calories
                })
                .Select(g => new
                 {
                    g.Key.Food,
                    g.Key.Calories 
                 }).OrderByDescending(q => q.Calories).ToList();

            graphData = graphData.Take(10).Select(p => p).ToList();
            // Loading drop down lists.
            //return (Json(graphData, JsonRequestBehavior.AllowGet));
            return (Json(graphData, JsonRequestBehavior.AllowGet));
        }

        }
    }
