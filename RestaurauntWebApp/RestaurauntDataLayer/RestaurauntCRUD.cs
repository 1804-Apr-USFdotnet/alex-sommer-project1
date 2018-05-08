using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurauntDataLayer;
//merge with library

namespace RestaurauntDataLayer
{
    public class RestaurauntCRUD
    {
        public RestaurauntDataEntities db = new RestaurauntDataEntities();

        public IEnumerable<Restauraunt> GetRestauraunts()
        {
           
            return db.Restauraunts;
        }
        //find restaraunt
        public Restauraunt FindRestarauntById(int? searchId)
        {
            return db.Restauraunts.Find(searchId);
        }
        public Review FindReviewById(int searchId)
        {
            return db.Reviews.Find(searchId);
        }
        public Restauraunt FindRestarauntByName(string searchName)
        {
            var sample = db.Restauraunts
                .Where(r => r.Name == searchName)
                .FirstOrDefault();
            return sample;
        }
        public void AddRestaraunt(Restauraunt subject)
        {
            db.Restauraunts.Add(subject);
            db.SaveChanges();
        }
        public void AddReview(Review newRev)
        {
            db.Reviews.Add(newRev);
            db.SaveChanges();
        }
        //public void ChangeRestarauntName(int restId, string newName)
        //{
        //    var target = FindRestarauntById(restId);
        //    target.Name = newName;
        //    db.SaveChanges();
        //}
        public void DeleteRestaraunt(int delId)
        {
            var delRest = FindRestarauntById(delId);
            db.Restauraunts.Remove(delRest);
            db.SaveChanges();
        }
        public void DeleteReview(int DelId)
        {
            var delRev = FindReviewById(DelId);
            db.Reviews.Remove(delRev);
            db.SaveChanges();
        }
        public void UpdateRestauraunt(int restId, Restauraunt changed)
        {
            var old = FindRestarauntById(restId);
            old.Name = changed.Name;
            old.City = changed.City;
            old.State = changed.State;
            old.Address = changed.Address;
            db.SaveChanges();
        }
        public void UpdateReview(int revId, Review changed)
        {
            var old = FindReviewById(revId);
            old.ReviewerName = changed.ReviewerName;
            old.ReviewerRating = changed.ReviewerRating;
            old.ReviewerComment = changed.ReviewerComment;
            db.SaveChanges();
        }
        public List<Review> GetReviews(int searchId)
        {
            return db.Reviews.Where(x => x.RestID.Equals(searchId)).ToList();
        }
        public List<Restauraunt> SearchRestaraunts(string searchName)
        {
            return db.Restauraunts.Where(b => b.Name.Contains(searchName)).ToList();
        }
        public List<Restauraunt> ListAllRestaraunts()
        {
            List<Restauraunt> fullList = null;
            foreach (Restauraunt r in db.Restauraunts)
            {
                fullList.Add(r);
            }
            return fullList;
        }
    }
}
