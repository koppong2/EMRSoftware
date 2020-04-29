namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReceiptType")]
    public partial class ReceiptType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReceiptType()
        {
            PatientBills = new HashSet<PatientBill>();
            Receipts = new HashSet<Receipt>();
        }

        [StringLength(50)]
        [Display(Name = "Receipt Type")]
        public string ReceiptTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiptTypeName { get; set; }

        [StringLength(50)]
        public string ReceiptType1 { get; set; }

        [StringLength(50)]
        public string ReceiptType2 { get; set; }

        [StringLength(50)]
        public string ReceiptType3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
