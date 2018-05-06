using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurauntDataLayer;

namespace RestaurauntLibrary
{
    public class Restauraunt
    {
        //average rating property?? method?

        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }

        public float GetAverage()
        {
            float tempSum = 0F;
            foreach (Review r in Reviews)
            {
                tempSum += (float)r.ReviewerRating;
            }
            return (tempSum / Reviews.Count);
        }

        public static Restauraunt DMap(RestaurauntDataLayer.Restauraunt dr)
        {
            Restauraunt r = new Restauraunt();
            r.ID = dr.ID;
            r.Name = dr.Name;
            r.City = dr.City;
            r.State = dr.State;
            r.Address = dr.Address;
            r.Reviews = new List<Review>();
            foreach (var review in dr.Reviews)
            {
                var temp = new Review
                {
                    ID = review.ID,
                    RestID = review.RestID,
                    ReviewerName = review.ReviewerName,
                    ReviewerRating = review.ReviewerRating,
                    ReviewerComment = review.ReviewerComment
                };
                r.Reviews.Add(temp);
            }

            //for (int i = 0; i <dr.Reviews.Count; i++)
            //{
            //    r.Reviews.Add(Review.DMap(dr.Reviews.ElementAt(i)));
            //}
            return r;
        }

        public RestaurauntDataLayer.Restauraunt DUnmap()
        {
            RestaurauntDataLayer.Restauraunt dr = new RestaurauntDataLayer.Restauraunt
            {
                ID = this.ID,
                Name = this.Name,
                City = this.City,
                State = this.State,
                Address = this.Address
            };
            for (int i = 0; i < this.Reviews.Count; i++)
            {
                dr.Reviews.Add(this.Reviews.ElementAt(1).DUnmap());
            }
            return dr;
        }
        
        
    }
}
