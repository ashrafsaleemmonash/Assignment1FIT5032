using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1FIT5032.Models
{
    public class RatingAverage
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public long Postal_Code { get; set; }
        public string Operating_Hours { get; set; }
        public double averageRating { get; set; }
    }


}