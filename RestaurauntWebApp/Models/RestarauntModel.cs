using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using RestaurauntDataLayer;
//using RestarauntReviewerLibrary;

namespace RestaurauntWebApp.Models
{
    public class RestRevViewModel
    {
        public Restauraunt Restauraunt(get; set; )
    }

    public class Review
    {
        public int ID { get; set; }
        public int RestID { get; set; }
        public int ReviewerRating { get; set; } 
        public string ReviewerName { get; set; }
        public string Reviewercomment { get; set; }
    }

    public class Restauraunt
    {
        private RestarauntContext db = new RestarauntContext();
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public List<Review> Reviews;

        public IEnumerable<Restauraunt> GetRestauraunts()
        {
            return db.restauraunts.ToList();
        }
    }

    

}