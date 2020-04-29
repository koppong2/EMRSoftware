namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DrugType")]
    public partial class DrugType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrugType()
        {
            Drugs = new HashSet<Drug>();
        }

        [StringLength(50)]
        public string DrugTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string DrugTypeName { get; set; }

        [StringLength(50)]
        public string DrugType1 { get; set; }

        [StringLength(50)]
        public string DrugType2 { get; set; }

        [StringLength(50)]
        public string DrugType3 { get; set; }

        [StringLength(50)]
        public string DrugType4 { get; set; }

        [StringLength(50)]
        public string DrugType5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Drug> Drugs { get; set; }
    }
}
