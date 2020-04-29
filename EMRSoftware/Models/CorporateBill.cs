namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CorporateBill")]
    public partial class CorporateBill
    {
        [StringLength(50)]
        public string CorporateBillID { get; set; }

        [StringLength(50)]
        public string GenderID { get; set; }

        [StringLength(50)]
        public string CorpBillStatusID { get; set; }

        public DateTime? CorporateBillName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(50)]
        public string KeyPrefix { get; set; }

        [StringLength(50)]
        public string AgeGroupID { get; set; }

        [StringLength(50)]
        public string InsuranceTypeID { get; set; }

        [StringLength(50)]
        public string SponsorID { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientID { get; set; }

        [Required]
        [StringLength(50)]
        public string VisitationID { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingGroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string InsuranceNo { get; set; }

        [StringLength(50)]
        public string BillUserID { get; set; }

        public DateTime? BillProcessDate { get; set; }

        public DateTime? BillDate1 { get; set; }

        public DateTime? BillDate2 { get; set; }

        public DateTime? BillDate3 { get; set; }

        public DateTime? BillDate4 { get; set; }

        [StringLength(50)]
        public string BillAmt4 { get; set; }

        [StringLength(50)]
        public string BillAmt3 { get; set; }

        [StringLength(50)]
        public string BillAmt2 { get; set; }

        [StringLength(50)]
        public string BillAmt1 { get; set; }

        [StringLength(50)]
        public string RevenueCenterID { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingDayID { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingMonthID { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingYearID { get; set; }

        [Required]
        [StringLength(50)]
        public string TableID { get; set; }

        [StringLength(50)]
        public string CorporateBill1 { get; set; }

        [StringLength(50)]
        public string CorporateBill2 { get; set; }

        [StringLength(50)]
        public string CorporateBill3 { get; set; }

        [StringLength(50)]
        public string CorporateBill4 { get; set; }

        [StringLength(50)]
        public string CorporateBill5 { get; set; }

        [StringLength(50)]
        public string CorporateBill6 { get; set; }

        [StringLength(50)]
        public string CorporateBill7 { get; set; }

        [StringLength(50)]
        public string CorporateBill8 { get; set; }

        public virtual AgeGroup AgeGroup { get; set; }

        public virtual BillingDay BillingDay { get; set; }

        public virtual BillingGroup BillingGroup { get; set; }

        public virtual BillingMonth BillingMonth { get; set; }

        public virtual BillingYear BillingYear { get; set; }

        public virtual CorpBillStatu CorpBillStatu { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual RevenueCenter RevenueCenter { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        public virtual Table Table { get; set; }

        public virtual Visitation Visitation { get; set; }
    }
}
