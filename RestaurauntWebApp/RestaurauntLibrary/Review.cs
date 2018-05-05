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
        public void DMap(RestaurauntDataLayer.Review dr)
        {
            this.ID = dr.ID;
            this.RestID = dr.RestID;
            this.ReviewerName = dr.ReviewerName;
            this.ReviewerRating = dr.ReviewerRating;
            this.ReviewerComment = dr.ReviewerComment;
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
