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
    
    public partial class tblRoleConfig
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRoleConfig()
        {
            this.tblAdminProfiles = new HashSet<tblAdminProfile>();
        }
    
        public int RoleConfigID { get; set; }
        public string Category { get; set; }
        public Nullable<bool> CanCreate { get; set; }
        public Nullable<bool> CanRead { get; set; }
        public Nullable<bool> CanUpdate { get; set; }
        public Nullable<bool> CanDelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAdminProfile> tblAdminProfiles { get; set; }
    }
}
