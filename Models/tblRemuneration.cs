//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ALMAL_Freelancer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRemuneration
    {
        public int RemunerationID { get; set; }
        public Nullable<int> UserProfileID { get; set; }
        public Nullable<int> Amount { get; set; }
        public string RegDate { get; set; }
    
        public virtual tblUserProfile tblUserProfile { get; set; }
    }
}
