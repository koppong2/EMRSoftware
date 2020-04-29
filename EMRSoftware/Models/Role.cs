namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            SystemUsers = new HashSet<SystemUser>();
        }

        [StringLength(50)]
        public string RoleID { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

        [StringLength(50)]
        public string Role1 { get; set; }

        [StringLength(50)]
        public string Role2 { get; set; }

        [StringLength(50)]
        public string Role3 { get; set; }

        [StringLength(50)]
        public string Role4 { get; set; }

        [StringLength(50)]
        public string Role5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
