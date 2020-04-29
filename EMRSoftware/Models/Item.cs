namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            IncomingItemsDetails = new HashSet<IncomingItemsDetail>();
        }

        [StringLength(50)]
        public string ItemID { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitCost { get; set; }

        [StringLength(50)]
        public string Item1 { get; set; }

        [StringLength(50)]
        public string Item2 { get; set; }

        [StringLength(50)]
        public string Item3 { get; set; }

        [StringLength(50)]
        public string Item4 { get; set; }

        [StringLength(50)]
        public string Item5 { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncomingItemsDetail> IncomingItemsDetails { get; set; }
    }
}
