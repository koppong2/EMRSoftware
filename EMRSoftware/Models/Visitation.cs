namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visitation")]
    public partial class Visitation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visitation()
        {
            ConsultReviews = new HashSet<ConsultReview>();
            CorporateBills = new HashSet<CorporateBill>();
            DrugSales = new HashSet<DrugSale>();
            PatientBills = new HashSet<PatientBill>();
            Diagnosis = new HashSet<Diagnosi>();
            DrugSaleItems = new HashSet<DrugSaleItem>();
            Services = new HashSet<Service>();
        }

        [StringLength(50)]
        [Key]
        public string VisitationID { get; set; }

        [Required]
        [StringLength(100)]
        public string VisitationName { get; set; }

        [Required]
        [StringLength(50)]
        public string VisitTypeID { get; set; }

        public DateTime VisitDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientID { get; set; }

        [Required]
        [StringLength(50)]
        public string SponsorID { get; set; }

        [Required]
        [StringLength(50)]
        public string SubSponsorID { get; set; }

        [Required]
        [StringLength(50)]
        public string SpecialtyID { get; set; }

        [Required]
        [StringLength(50)]
        public string ConsultationID { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorID { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingGroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string Age { get; set; }

        [Required]
        [StringLength(50)]
        public string AgeGroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string InsuranceTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string InsuranceValID { get; set; }

        [Required]
        [StringLength(50)]
        public string Cost { get; set; }

        [StringLength(50)]
        public string copayAmt { get; set; }

        [Required]
        [StringLength(50)]
        public string VisitStatusID { get; set; }

        [Required]
        [StringLength(50)]
        public string RevenueCenterID { get; set; }

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
        [Display(Name ="Receipt")]
        public string ReceiptNo { get; set; }

        [StringLength(50)]
        public string Visitation2 { get; set; }

        [StringLength(50)]
        public string Visitation3 { get; set; }

        [StringLength(50)]
        public string Visitation4 { get; set; }

        [StringLength(50)]
        public string Visitation5 { get; set; }

        public virtual AgeGroup AgeGroup { get; set; }

        public virtual BillingGroup BillingGroup { get; set; }

        public virtual Consultation Consultation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultReview> ConsultReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        public virtual Doctor Doctor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSale> DrugSales { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }

        public virtual InsuranceVal InsuranceVal { get; set; }

        public virtual Patient Patient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }

        public virtual RevenueCenter RevenueCenter { get; set; }

        public virtual Specialty Specialty { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        public virtual SubSponsor SubSponsor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnosi> Diagnosis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSaleItem> DrugSaleItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Services { get; set; }

        public virtual VisitStatu VisitStatu { get; set; }

        public virtual VisitType VisitType { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }
    }
}
