namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PatientBill")]
    public partial class PatientBill
    {
        [StringLength(50)]
        public string PatientBillID { get; set; }

        [StringLength(50)]
        public string PatientID { get; set; }

        [StringLength(50)]
        public string VisitationID { get; set; }

        [StringLength(50)]
        public string TableID { get; set; }

        [StringLength(50)]
        public string SponsorID { get; set; }

        [StringLength(50)]
        public string BillingGroupID { get; set; }

        [StringLength(50)]
        public string InsuranceTypeID { get; set; }

        [StringLength(50)]
        public string InsuranceNo { get; set; }

        [StringLength(50)]
        public string ReceiptID { get; set; }

        [StringLength(50)]
        public string ReceiptStatusID { get; set; }

        [StringLength(50)]
        public string ReceiptTypeID { get; set; }

        public DateTime? ReceiptDate1 { get; set; }

        public DateTime? ReceiptDate2 { get; set; }

        public DateTime? ReceiptDate3 { get; set; }

        public DateTime? ReceiptDate4 { get; set; }

        [StringLength(50)]
        public string ReceiptAmt1 { get; set; }

        [StringLength(50)]
        public string ReceiptAmt2 { get; set; }

        [StringLength(50)]
        public string ReceiptAmt3 { get; set; }

        [StringLength(50)]
        public string ReceiptAmt4 { get; set; }

        [StringLength(50)]
        public string ChequeDueDate { get; set; }

        [StringLength(80)]
        public string PaymentModeDetails { get; set; }

        [StringLength(50)]
        public string SystemUserID { get; set; }

        [StringLength(50)]
        public string GenderID { get; set; }

        [StringLength(50)]
        public string BillUserID { get; set; }

        [StringLength(50)]
        public string BillingDayID { get; set; }

        [StringLength(50)]
        public string BIllingMonthID { get; set; }

        [StringLength(50)]
        public string BillingYearID { get; set; }

        public DateTime? BillProcessDate { get; set; }

        [StringLength(50)]
        public string PatientBill1 { get; set; }

        [StringLength(50)]
        public string PatientBill2 { get; set; }

        [StringLength(50)]
        public string PatientBill3 { get; set; }

        [StringLength(50)]
        public string PatientBill4 { get; set; }

        [StringLength(50)]
        public string PatientBill5 { get; set; }

        [StringLength(50)]
        public string PatientBill6 { get; set; }

        [StringLength(50)]
        public string PatientBill7 { get; set; }

        [StringLength(50)]
        public string PatientBill8 { get; set; }

        [StringLength(50)]
        public string PatientBill9 { get; set; }

        public virtual BillingDay BillingDay { get; set; }

        public virtual BillingGroup BillingGroup { get; set; }

        public virtual BillingMonth BillingMonth { get; set; }

        public virtual BillingYear BillingYear { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Receipt Receipt { get; set; }

        public virtual ReceiptStatu ReceiptStatu { get; set; }

        public virtual ReceiptType ReceiptType { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        public virtual SystemUser SystemUser { get; set; }

        public virtual Table Table { get; set; }

        public virtual Visitation Visitation { get; set; }
    }
}
