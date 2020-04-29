namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemCategory")]
    public partial class ItemCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemCategory()
        {
            Items = new HashSet<Item>();
        }

        [StringLength(50)]
        public string ItemCategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemCategoryName { get; set; }

        [StringLength(50)]
        public string ItemCategory1 { get; set; }

        [StringLength(50)]
        public string ItemCategory2 { get; set; }

        public virtual ItemCategory ItemCategory11 { get; set; }

        public virtual ItemCategory ItemCategory3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
