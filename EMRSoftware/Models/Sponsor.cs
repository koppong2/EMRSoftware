namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sponsor")]
    public partial class Sponsor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sponsor()
        {
            BillingGroups = new HashSet<BillingGroup>();
            ConsultReviews = new HashSet<ConsultReview>();
            CorporateBills = new HashSet<CorporateBill>();
            DrugSales = new HashSet<DrugSale>();
            PatientBills = new HashSet<PatientBill>();
            Diagnosis = new HashSet<Diagnosi>();
            SponsorCategories = new HashSet<SponsorCategory>();
            SubSponsors = new HashSet<SubSponsor>();
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string SponsorID { get; set; }

        [Required]
        [StringLength(100)]
        public string SponsorName { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusID { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string PostalAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string InsuranceTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string RegionID { get; set; }

        [StringLength(100)]
        public string ClaimsInfo { get; set; }

        [StringLength(50)]
        public string Sponsor1 { get; set; }

        [StringLength(50)]
        public string Sponsor2 { get; set; }

        [StringLength(50)]
        public string Sponsor3 { get; set; }

        [StringLength(50)]
        public string Sponsor4 { get; set; }

        [StringLength(50)]
        public string Sponsor5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillingGroup> BillingGroups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultReview> ConsultReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSale> DrugSales { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }

        public virtual Region Region { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnosi> Diagnosis { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SponsorCategory> SponsorCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubSponsor> SubSponsors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
