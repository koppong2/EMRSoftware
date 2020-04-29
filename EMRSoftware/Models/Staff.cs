namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            SystemUsers = new HashSet<SystemUser>();
        }

        [StringLength(50)]
        public string StaffId { get; set; }

        [Required]
        [StringLength(100)]
        public string StaffName { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitId { get; set; }

        [StringLength(50)]
        public string Staff1 { get; set; }

        [StringLength(50)]
        public string Staff2 { get; set; }

        [StringLength(50)]
        public string Staff3 { get; set; }

        [StringLength(50)]
        public string Staff4 { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemUser> SystemUsers { get; set; }
    }
}
