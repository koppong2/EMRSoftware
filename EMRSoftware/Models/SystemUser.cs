namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemUser")]
    public partial class SystemUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SystemUser()
        {
            PatientBills = new HashSet<PatientBill>();
        }

        [StringLength(50)]
        public string systemUserId { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffId { get; set; }

        [Required]
        [StringLength(50)]
        public string roleid { get; set; }

        [Required]
        [StringLength(50)]
        public string statusId { get; set; }

        [StringLength(50)]
        public string systemuser1 { get; set; }

        [StringLength(50)]
        public string systemuser2 { get; set; }

        [StringLength(50)]
        public string systemuser3 { get; set; }

        [StringLength(50)]
        public string systemuser4 { get; set; }

        [StringLength(50)]
        public string systemuser5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }

        public virtual Role Role { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Status Status { get; set; }
    }
}
