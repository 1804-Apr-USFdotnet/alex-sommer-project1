using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace RestarauntReviewerLibrary
{
    [DataContract]
    public class Restauraunt
    {
        //Fields
        //----------------
        //public int resaurauntID;
        [IgnoreDataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Address { get; set; }

        [IgnoreDataMember]
        public float averageReview;
        [DataMember]
        public List<Review> Reviews;//how do I serialize a list of objects that is a part of another object?
        //Constructors
        //-----------------
        //minimum required constructors
        public Restauraunt()
        {
            Reviews = new List<Review>();
        }
        public Restauraunt(string name)
        {
            Name = name;
            Reviews = new List<Review>();
        }
        public Restauraunt(int id, string name, string city, string state, string address)
        {
            ID = id;
            Name = name;
            City = city;
            State = state;
            Address = address;
            Reviews = new List<Review>();
        }
        //Methods
        //-------------------
        public void SetAverage() //call after changes to reviews
        {
            float tempSum = 0F;
            foreach (Review r in Reviews)
            {
                tempSum += (float)r.ReviewerRating;
            }
            averageReview = tempSum / Reviews.Count;
        }
        public float GetAverage() //REFACTOR THIS PART
        {
            float tempSum = 0F;
            foreach (Review r in Reviews)
            {
                tempSum += (float)r.ReviewerRating;
            }
            return  (tempSum / Reviews.Count);
        }
        
        public void addReview(int id, int rating, string name)
        {
            Reviews.Add(new Review(ID ,rating, name));
            SetAverage();
        }
        
        public override string ToString()
        {
            return ($"{ID} {Name} {City} {State} {Address}");
        }

    }
}
