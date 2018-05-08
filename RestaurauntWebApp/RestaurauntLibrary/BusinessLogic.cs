using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace RestaurauntLibrary
{
    

    public class BusinessLogic
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        RestaurauntDataLayer.RestaurauntCRUD crud;
        //List<Restauraunt> silo;

        public BusinessLogic()
        {
            try
            {
                crud = new RestaurauntDataLayer.RestaurauntCRUD();

            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
           // silo = GetRestauraunts();
        }

        public void AddRestauraunt(Restauraunt rest)
        {
            try
            {
                crud.AddRestaraunt(rest.DUnmap());
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
        }
        public void AddReview( Review newRev)
        {
            //newRev.RestID = restId;
            try
            {
                crud.AddReview(newRev.DUnmap());
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
        }
        public void DeleteRestauraunt( Restauraunt target)
        {
            try
            {
                crud.DeleteRestaraunt(target.ID);
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
            
        }
        public void DeleteReview(int delId)
        {
            try
            {
                crud.DeleteReview(delId);
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
        }
        public void UpdateRestauraunt(Restauraunt uRest)
        {
            try
            {
                crud.UpdateRestauraunt(uRest.ID, uRest.DUnmap());
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
        }
        public void UpdateReview(Review uRev)
        {
            try
            {
                crud.UpdateReview(uRev.ID, uRev.DUnmap());
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
        }
        public Review GetReviewById (int searchId)
        {
            try
            {
                return Review.DMap(crud.FindReviewById(searchId));

            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
        }

        public Restauraunt GetRestauraunt(int? searchId)
        {
            try
            {
                return Restauraunt.DMap(crud.FindRestarauntById(searchId));
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
            
        }

        public List<RestaurauntLibrary.Restauraunt> GetRestauraunts()
        {
            try
            {
                var rests = crud.GetRestauraunts();
                List<RestaurauntLibrary.Restauraunt> results = new List<Restauraunt>();
                foreach (RestaurauntDataLayer.Restauraunt r in rests)
                {
                    results.Add(RestaurauntLibrary.Restauraunt.DMap(r));
                }
                return results;
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
            
        }
        public List<RestaurauntLibrary.Restauraunt> SortByName()
        {
            try
            {
                var rests = crud.GetRestauraunts();
                List<RestaurauntLibrary.Restauraunt> results = new List<Restauraunt>();
                foreach (RestaurauntDataLayer.Restauraunt r in rests)
                {
                    results.Add(RestaurauntLibrary.Restauraunt.DMap(r));
                }
                results = results.OrderBy(b => b.Name).ToList();
                return results;
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
            
        }

        public List<Restauraunt> SearchRestaraunts(string searchName)
        {
            try
            {
                List<RestaurauntDataLayer.Restauraunt> results = crud.SearchRestaraunts(searchName);
                List<Restauraunt> cleanList = new List<Restauraunt>();
                foreach (RestaurauntDataLayer.Restauraunt r in results)
                {
                    cleanList.Add(Restauraunt.DMap(r));
                }
                return cleanList;
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
            
        }
        public List<Review> GetReviews(int RestId)
        {
            try
            {
                List<Review> results = new List<Review>();
                List<RestaurauntDataLayer.Review> data = crud.GetReviews(RestId);
                foreach (RestaurauntDataLayer.Review r in data)
                {
                    results.Add(Review.DMap(r));
                }
                return results;
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                throw;
            }
            
        }
        

        public static List<RestaurauntLibrary.Restauraunt> TopThree(List<RestaurauntLibrary.Restauraunt> candidates)
        {
            List<Restauraunt> results = new List<Restauraunt>();
            List<Restauraunt> workspace = candidates;
            float Best = 0F;
            Restauraunt top = null;
            foreach (Restauraunt r in workspace)
            {
                if (r.GetAverage() > Best)
                {
                    Best = r.GetAverage();
                    top = r;
                }
            }
            workspace.Remove(top);
            float SecondBest = 0F;
            Restauraunt second = null;
            foreach (Restauraunt r in workspace)
            {
                if (r.GetAverage() > SecondBest)
                {
                    SecondBest = r.GetAverage();
                    second = r;
                }
            }
            workspace.Remove(second);
            float ThirdBest = 0F;
            Restauraunt third = null;
            foreach (Restauraunt r in workspace)
            {
                if (r.GetAverage() > ThirdBest)
                {
                    ThirdBest = r.GetAverage();
                    third = r;
                }
            }
            results.Add(top);
            results.Add(second);
            results.Add(third);

            return results;
        }
    }
}
