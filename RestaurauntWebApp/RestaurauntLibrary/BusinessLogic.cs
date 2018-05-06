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
    }
}
