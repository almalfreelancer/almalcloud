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
    
    public partial class tblMedia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMedia()
        {
            this.tblFeaturedProfiles = new HashSet<tblFeaturedProfile>();
        }
    
        public int MediaID { get; set; }
        public Nullable<int> UserProfileID { get; set; }
        public string ContentUrl { get; set; }
        public string Type { get; set; }
        public Nullable<bool> IsBlocked { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFeaturedProfile> tblFeaturedProfiles { get; set; }
        public virtual tblUserProfile tblUserProfile { get; set; }
    }
}
