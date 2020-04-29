namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillingYear")]
    public partial class BillingYear
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillingYear()
        {
            CorporateBills = new HashSet<CorporateBill>();
            PatientBills = new HashSet<PatientBill>();
        }

        [StringLength(50)]
        public string BillingYearID { get; set; }

        [StringLength(70)]
        public string BillingYearName { get; set; }

        [StringLength(50)]
        public string BillingYear1 { get; set; }

        [StringLength(50)]
        public string BillingYear2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }
    }
}
