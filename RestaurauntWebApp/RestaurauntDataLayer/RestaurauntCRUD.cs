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
        public Restauraunt FindRestarauntById(int searchId)
        {
            return db.Restauraunts.Find(searchId);
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
        public void ChangeRestarauntName(int restId, string newName)
        {
            var target = FindRestarauntById(restId);
            target.Name = newName;
            db.SaveChanges();
        }
        public void DeleteRestaraunt(int delId)
        {
            var delRest = FindRestarauntById(delId);
            db.Restauraunts.Remove(delRest);
            db.SaveChanges();
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
