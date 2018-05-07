using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurauntLibrary
{
    public class BusinessLogic
    {
        RestaurauntDataLayer.RestaurauntCRUD crud;
        //List<Restauraunt> silo;

        public BusinessLogic()
        {
            crud = new RestaurauntDataLayer.RestaurauntCRUD();
           // silo = GetRestauraunts();
        }

        public void AddRestauraunt(Restauraunt rest)
        {
            crud.AddRestaraunt(rest.DUnmap());
        }
        public void AddReview(Review newRev)
        {
            crud.AddReview(newRev.DUnmap());
        }
        public void DeleteRestauraunt( Restauraunt target)
        {
            crud.DeleteRestaraunt(target.ID);
        }
        public void DeleteReview(Review delRev)
        {
            crud.DeleteReview(delRev.ID);
        }
        public void UpdateRestauraunt(Restauraunt uRest)
        {
            crud.UpdateRestauraunt(uRest.ID, uRest.DUnmap());
        }
        public void UpdateReview(Review uRev)
        {
            crud.UpdateReview(uRev.ID, uRev.DUnmap());
        }

        public List<RestaurauntLibrary.Restauraunt> GetRestauraunts()
        {
            var rests = crud.GetRestauraunts();
            List<RestaurauntLibrary.Restauraunt> results = new List<Restauraunt>();
            foreach (RestaurauntDataLayer.Restauraunt r in rests)
            {
                results.Add(RestaurauntLibrary.Restauraunt.DMap(r));
            }
            return results;
        }
       
        public List<Restauraunt> SearchRestaraunts(string searchName)
        {
            List<RestaurauntDataLayer.Restauraunt>results = crud.SearchRestaraunts(searchName);
            List<Restauraunt> cleanList = new List<Restauraunt>();
            foreach(RestaurauntDataLayer.Restauraunt r in results)
            {
                cleanList.Add(Restauraunt.DMap(r));
            }
            return cleanList;
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
