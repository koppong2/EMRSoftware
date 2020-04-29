namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillingGroup")]
    public partial class BillingGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillingGroup()
        {
            CorporateBills = new HashSet<CorporateBill>();
            PatientBills = new HashSet<PatientBill>();
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string BillingGroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientID { get; set; }

        [Required]
        [StringLength(50)]
        public string SponsorID { get; set; }

        [Required]
        [StringLength(50)]
        public string SubSponsorID { get; set; }

        [StringLength(50)]
        public string SponsorCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string InitialDependantID { get; set; }

        [Required]
        [StringLength(50)]
        public string RelationID { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusID { get; set; }

        [StringLength(50)]
        public string InsuranceNo { get; set; }

        [StringLength(50)]
        public string BillingGroup1 { get; set; }

        [StringLength(50)]
        public string BillingGroup2 { get; set; }

        [StringLength(50)]
        public string BillingGroup3 { get; set; }

        [StringLength(50)]
        public string BillingGroup4 { get; set; }

        [StringLength(50)]
        public string BillingGroup5 { get; set; }

      //  public virtual BillingGroup BillingGroup11 { get; set; }

     //   public virtual BillingGroup BillingGroup6 { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Relation Relation { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        public virtual SponsorCategory SponsorCategory { get; set; }

        public virtual Status Status { get; set; }

        public virtual SubSponsor SubSponsor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
