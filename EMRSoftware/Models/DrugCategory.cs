namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrugCategory")]
    public partial class DrugCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrugCategory()
        {
            Drugs = new HashSet<Drug>();
        }

        [StringLength(50)]
        public string DrugCategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string DrugCategoryName { get; set; }

        [StringLength(10)]
        public string DrugCategory1 { get; set; }

        [StringLength(10)]
        public string DrugCategory2 { get; set; }

        [StringLength(10)]
        public string DrugCategory3 { get; set; }

        [StringLength(10)]
        public string DrugCategory4 { get; set; }

        [StringLength(10)]
        public string DrugCategory5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Drug> Drugs { get; set; }
    }
}
