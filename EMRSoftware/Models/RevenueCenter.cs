namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RevenueCenter")]
    public partial class RevenueCenter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RevenueCenter()
        {
            ConsultReviews = new HashSet<ConsultReview>();
            CorporateBills = new HashSet<CorporateBill>();
            DrugSales = new HashSet<DrugSale>();
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string RevenueCenterID { get; set; }

        [Required]
        [StringLength(100)]
        public string RevenueCenterName { get; set; }

        [StringLength(50)]
        public string RevenueCenter1 { get; set; }

        [StringLength(50)]
        public string RevenueCenter2 { get; set; }

        [StringLength(50)]
        public string RevenueCenter3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultReview> ConsultReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSale> DrugSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
