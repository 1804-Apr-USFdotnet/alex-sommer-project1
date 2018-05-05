using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurauntWebApp.Models
{
    public class ReviewWebModel
    {
        public int ID { get; set; }
        public int RestID { get; set; }
        public string ReviewerName { get; set; }
        public Nullable<int> ReviewerRating { get; set; }
        public string ReviewerComment { get; set; }

        //public virtual RestaurauntWebModel Restauraunt { get; set; }

        public ReviewWebModel Map (RestaurauntDataLayer.Review dr)
        {
            this.ID = dr.ID;
            this.RestID = dr.RestID;
            this.ReviewerName = dr.ReviewerName;
            this.ReviewerRating = dr.ReviewerRating;
            this.ReviewerComment = dr.ReviewerComment;
            //this.restauraunt?
            return this;
        }

        public RestaurauntDataLayer.Review ReverseMap (ReviewWebModel wr)
        {
            RestaurauntDataLayer.Review dr = new RestaurauntDataLayer.Review
            {
                ID = wr.ID,
                RestID = wr.RestID,
                ReviewerName = wr.ReviewerName,
                ReviewerRating = wr.ReviewerRating,
                ReviewerComment = wr.ReviewerComment
            };
            //restauraunt property?
            return dr;
        }
    }
}