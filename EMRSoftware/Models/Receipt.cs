namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Receipt")]
    public partial class Receipt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receipt()
        {
            PatientBills = new HashSet<PatientBill>();
            Refunds = new HashSet<Refund>();
        }

        [StringLength(50)]
        [Display(Name ="Receipt ID")]
        public string ReceiptID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Hosp ID")]
        public string PatientID { get; set; }

        public DateTime ReceiptDate { get; set; }

        [StringLength(60)]
        [Required]
        [Display(Name ="Name")]
        public string ReceiptName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Receipt Type")]
        public string ReceiptTypeID { get; set; }

        [Required]
        [StringLength(20)]
        public string ManualReceipt { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiptStatusID { get; set; }

        [StringLength(20)]
        [Display(Name ="Paid Amt")]
        public string ReceiptAmount { get; set; }

        [StringLength(20)]
        public string ReceiptAmt1 { get; set; }

        [StringLength(20)]
        [Display(Name = "Amt Used")]
        public string ReceiptAmt2 { get; set; }

        [StringLength(20)]
        [Display(Name = "Outstanding")]
        public string ReceiptAmt3 { get; set; }

        public DateTime? ReceiptDate1 { get; set; }

        public DateTime? ReceiptDate2 { get; set; }

        public DateTime? ReceiptDate3 { get; set; }

        public DateTime? ReceiptDate4 { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkingYearID { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkingMonthID { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkingDayID { get; set; }

        [StringLength(50)]
        [Required]
        public string Purpose { get; set; }

        [StringLength(70)]
        public string BankName { get; set; }

        [StringLength(50)]
        public string ChequeNo { get; set; }

        [StringLength(100)]
        public string ChequeDetails { get; set; }


        public DateTime? ChequeDate { get; set; }

        [StringLength(50)]
        public string Receipt1 { get; set; }

        [StringLength(50)]
        public string Receipt2 { get; set; }

        [StringLength(50)]
        public string Receipt3 { get; set; }

        [StringLength(50)]
        public string Receipt4 { get; set; }

        [StringLength(50)]
        public string Receipt5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }

        public virtual ReceiptStatu ReceiptStatu { get; set; }

        public virtual ReceiptType ReceiptType { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Refund> Refunds { get; set; }
    }
}
