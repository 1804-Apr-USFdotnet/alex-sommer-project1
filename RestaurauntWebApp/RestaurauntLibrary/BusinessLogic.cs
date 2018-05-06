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

        public BusinessLogic()
        {
            crud = new RestaurauntDataLayer.RestaurauntCRUD();
        }

        public void AddRestauraunt()
        {

        }
        public void AddReview() { }
        public void DeleteRestauraunt() { }
        public void DeleteReview() { }
        public void UpdateRestauraunt() { }
        public void UpdateReview() { }

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
