namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gender")]
    public partial class Gender
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gender()
        {
            CorporateBills = new HashSet<CorporateBill>();
            Patients = new HashSet<Patient>();
            PatientBills = new HashSet<PatientBill>();
        }

        [StringLength(50)]
        public string GenderID { get; set; }

        [Required]
        [StringLength(100)]
        public string GenderName { get; set; }

        [StringLength(50)]
        public string Gender1 { get; set; }

        [StringLength(50)]
        public string Gender2 { get; set; }

        [StringLength(50)]
        public string Gender3 { get; set; }

        [StringLength(50)]
        public string Gender4 { get; set; }

        [StringLength(50)]
        public string Gender5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }
    }
}
