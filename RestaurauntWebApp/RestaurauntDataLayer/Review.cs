//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurauntDataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int ID { get; set; }
        public int RestID { get; set; }
        public string ReviewerName { get; set; }
        public Nullable<int> ReviewerRating { get; set; }
        public string ReviewerComment { get; set; }
    
        public virtual Restauraunt Restauraunt { get; set; }
    }
}
