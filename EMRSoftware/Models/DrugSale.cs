namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrugSale")]
    public partial class DrugSale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrugSale()
        {
            DrugSaleItems = new HashSet<DrugSaleItem>();
        }

        [StringLength(50)]
        public string DrugSaleID { get; set; }

        public DateTime DrugSaleDate { get; set; }

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

        [StringLength(50)]
        public string DrugSale1 { get; set; }

        [StringLength(50)]
        public string DrugSale2 { get; set; }

        [StringLength(50)]
        public string DrugSale3 { get; set; }

        [StringLength(50)]
        public string DrugSale4 { get; set; }

        [StringLength(50)]
        public string DrugSale5 { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual RevenueCenter RevenueCenter { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        public virtual Visitation Visitation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSaleItem> DrugSaleItems { get; set; }
    }
}
