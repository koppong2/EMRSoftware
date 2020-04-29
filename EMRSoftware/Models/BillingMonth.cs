namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillingMonth")]
    public partial class BillingMonth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillingMonth()
        {
            CorporateBills = new HashSet<CorporateBill>();
            PatientBills = new HashSet<PatientBill>();
        }

        [StringLength(50)]
        public string BillingMonthID { get; set; }

        [StringLength(70)]
        public string BillingMonthName { get; set; }

        [StringLength(50)]
        public string BillingMonth1 { get; set; }

        [StringLength(50)]
        public string BillingMonth2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }
    }
}
