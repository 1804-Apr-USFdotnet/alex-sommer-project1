using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurauntLibrary;

namespace RestaurauntWebApp.Models
{
    public class RestaurauntWebModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }

        public List<ReviewWebModel> Reviews { get; set; }

        //mapper
        public static RestaurauntWebModel Map(RestaurauntLibrary.Restauraunt dr)
        {
            var wr = new RestaurauntWebModel();
            wr.ID = dr.ID;
            wr.Name = dr.Name;
            wr.City = dr.City;
            wr.State = dr.State;
            wr.Address = dr.Address;
            foreach (Review r in dr.Reviews)
            {
                wr.Reviews.Add(ReviewWebModel.Map(r));
            }
            return wr; //???
        }
        public static RestaurauntLibrary.Restauraunt ReverseMap(RestaurauntWebModel wr)
        {
            RestaurauntLibrary.Restauraunt dr = new RestaurauntLibrary.Restauraunt//change to library method
            {
                ID = wr.ID,
                Name = wr.Name,
                City = wr.City,
                State = wr.State,
                Address = wr.Address
            };
            //dr.Reviews = wr.Reviews;
            return dr;
        }
        //public IEnumerable<RestaurauntWebModel> GetRestauraunts()
        //{
        //    //var rests = 
        //    //var result = rests.Select(x => Map(x));
        //    return result;
        //}


        //public RestaurauntWebModel GetRestaurauntById(int id)
        //{
        //    return Map(/*List of Lib Restauraunts taken from db .Where id=id*/);
        //}

        public void AddRestauraunt (RestaurauntWebModel resto)
        {
            //unmap to lib
            //then to crud
            //log the add on nlog
        }


    }
}