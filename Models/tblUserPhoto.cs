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
    
    public partial class tblUserPhoto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUserPhoto()
        {
            this.tblUserProfiles = new HashSet<tblUserProfile>();
        }
    
        public int UserPhotoID { get; set; }
        public string Url { get; set; }
        public Nullable<bool> IsProfilePhoto { get; set; }
        public string IsCoverPhoto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUserProfile> tblUserProfiles { get; set; }
    }
}