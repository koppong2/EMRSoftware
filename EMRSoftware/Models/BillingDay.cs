namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillingDay")]
    public partial class BillingDay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillingDay()
        {
            CorporateBills = new HashSet<CorporateBill>();
            PatientBills = new HashSet<PatientBill>();
        }

        [StringLength(50)]
        public string BillingDayID { get; set; }

        [StringLength(70)]
        public string BillingDayName { get; set; }

        [StringLength(50)]
        public string BillingDay1 { get; set; }

        [StringLength(50)]
        public string BillingDay2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }
    }
}
