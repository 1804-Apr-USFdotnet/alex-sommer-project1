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

        public static ReviewWebModel Map(RestaurauntLibrary.Review dr)
        {
            var wr = new ReviewWebModel();
            wr.ID = dr.ID;
            wr.RestID = dr.RestID;
            wr.ReviewerName = dr.ReviewerName;
            wr.ReviewerRating = dr.ReviewerRating;
            wr.ReviewerComment = dr.ReviewerComment;
            //this.restauraunt?
            return wr;
        }

        public RestaurauntLibrary.Review ReverseMap (ReviewWebModel wr)
        {
            RestaurauntLibrary.Review dr = new RestaurauntLibrary.Review
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