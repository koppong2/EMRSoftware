namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SponsorCategory")]
    public partial class SponsorCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SponsorCategory()
        {
            BillingGroups = new HashSet<BillingGroup>();
        }

        [StringLength(50)]
        public string SponsorCategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string SponsorCategoryName { get; set; }

        [Required]
        [StringLength(50)]
        public string SponsorID { get; set; }

        [Required]
        [StringLength(50)]
        public string SubSponsorID { get; set; }

        [StringLength(50)]
        public string SponsorCategory1 { get; set; }

        [StringLength(50)]
        public string SponsorCategory2 { get; set; }

        [StringLength(50)]
        public string SponsorCategory3 { get; set; }

        [StringLength(50)]
        public string SponsorCategory4 { get; set; }

        [StringLength(50)]
        public string SponsorCategory5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillingGroup> BillingGroups { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        public virtual SubSponsor SubSponsor { get; set; }
    }
}
