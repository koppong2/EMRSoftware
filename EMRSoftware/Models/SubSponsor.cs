namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubSponsor")]
    public partial class SubSponsor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubSponsor()
        {
            BillingGroups = new HashSet<BillingGroup>();
            SponsorCategories = new HashSet<SponsorCategory>();
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string SubSponsorID { get; set; }

        [Required]
        [StringLength(100)]
        public string SubSponsorName { get; set; }

        [Required]
        [StringLength(50)]
        public string SponsorID { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusID { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [StringLength(100)]
        public string PostalAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string RegionID { get; set; }

        [StringLength(200)]
        public string ClaimsInfo { get; set; }

        [StringLength(50)]
        public string SubSponsor1 { get; set; }

        [StringLength(50)]
        public string SubSponsor2 { get; set; }

        [StringLength(50)]
        public string SubSponsor3 { get; set; }

        [StringLength(50)]
        public string SubSponsor4 { get; set; }

        [StringLength(50)]
        public string SubSponsor5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillingGroup> BillingGroups { get; set; }

        public virtual Region Region { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SponsorCategory> SponsorCategories { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
