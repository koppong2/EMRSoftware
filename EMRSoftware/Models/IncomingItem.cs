namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IncomingItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IncomingItem()
        {
            IncomingItemsDetails = new HashSet<IncomingItemsDetail>();
        }

        [StringLength(50)]
        public string IncomingItemID { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierID { get; set; }

        public DateTime IncomingItemDate { get; set; }

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
        public string IncomingItem1 { get; set; }

        [StringLength(50)]
        public string IncomingItem2 { get; set; }

        [StringLength(50)]
        public string IncomingItem3 { get; set; }

        [StringLength(50)]
        public string IncomingItem4 { get; set; }

        [StringLength(50)]
        public string IncomingItem5 { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncomingItemsDetail> IncomingItemsDetails { get; set; }
    }
}
