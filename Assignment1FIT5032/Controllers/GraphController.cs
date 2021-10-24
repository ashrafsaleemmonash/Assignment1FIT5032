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
        [Authorize]// Allowing Only Logined In Accounts
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            // Initialization.  


                // Getting nutrional db value as a list  
                var nutritional = db.Nutritional_Value.ToList();

                // Filtering data to get the grouping of food & calories and arranging them in a descending order  
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

            // Filtering to only get the top 10 values
            graphData = graphData.Take(10).Select(p => p).ToList();

            //returning json format of the data values
            return (Json(graphData, JsonRequestBehavior.AllowGet));
        }

        }
    }
