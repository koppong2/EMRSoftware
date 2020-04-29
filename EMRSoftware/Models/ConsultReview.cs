namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConsultReview")]
    public partial class ConsultReview
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConsultReview()
        {
            Diagnosis = new HashSet<Diagnosi>();
            Services = new HashSet<Service>();
        }

        [StringLength(50)]
        public string ConsultReviewID { get; set; }

        [Required]
        [StringLength(100)]
        public string ConsultReviewName { get; set; }

        public DateTime ConsultReviewDate { get; set; }

        [Required]
        [StringLength(50)]
        public string VisitationID { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientID { get; set; }

        [Required]
        [StringLength(50)]
        public string SponsorID { get; set; }

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
        public string ConsultReview1 { get; set; }

        [StringLength(50)]
        public string ConsultReview2 { get; set; }

        [StringLength(50)]
        public string ConsultReview3 { get; set; }

        [StringLength(50)]
        public string ConsultReview4 { get; set; }

        [StringLength(50)]
        public string ConsultReview5 { get; set; }

        public virtual ConsultReview ConsultReview11 { get; set; }

        public virtual ConsultReview ConsultReview6 { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual RevenueCenter RevenueCenter { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        public virtual Visitation Visitation { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnosi> Diagnosis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Services { get; set; }
    }
}
