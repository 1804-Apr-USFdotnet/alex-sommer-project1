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
        public RestaurauntWebModel Map(RestaurauntLibrary.Restauraunt dr)
        {
            this.ID = dr.ID;
            this.Name = dr.Name;
            this.City = dr.City;
            this.State = dr.State;
            this.Address = dr.Address;
            //this.Reviews = dr.Reviews;
            return this; //???
        }
        public RestaurauntLibrary.Restauraunt ReverseMap(RestaurauntWebModel wr)
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
    }
}