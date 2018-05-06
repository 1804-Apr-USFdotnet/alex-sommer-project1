using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurauntDataLayer;

namespace RestaurauntLibrary
{
    public class Review
    {
        public int ID { get; set; }
        public int RestID { get; set; }
        public string ReviewerName { get; set; }
        public Nullable<int> ReviewerRating { get; set; }
        public string ReviewerComment { get; set; }

        //public virtual Restauraunt Restaraunt { get; set; }
        public static Review DMap(RestaurauntDataLayer.Review dr)
        {
            Review r = new Review();
            r.ID = dr.ID;
            r.RestID = dr.RestID;
            r.ReviewerName = dr.ReviewerName;
            r.ReviewerRating = dr.ReviewerRating;
            r.ReviewerComment = dr.ReviewerComment;
            return r;
        }
        public RestaurauntDataLayer.Review DUnmap()
        {
            RestaurauntDataLayer.Review dr = new RestaurauntDataLayer.Review()
            {
                ID = this.ID,
                RestID = this.RestID,
                ReviewerName = this.ReviewerName,
                ReviewerRating = this.ReviewerRating,
                ReviewerComment = this.ReviewerComment
            };
            return dr;
        }
    }

    
}
