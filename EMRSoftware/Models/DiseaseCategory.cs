namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiseaseCategory")]
    public partial class DiseaseCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiseaseCategory()
        {
            Diseases = new HashSet<Disease>();
        }

        [StringLength(50)]
        public string DiseaseCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string DiseaseCategoryName { get; set; }

        [StringLength(50)]
        public string DiseaseCategory1 { get; set; }

        [StringLength(50)]
        public string DiseaseCategory2 { get; set; }

        [StringLength(50)]
        public string DiseaseCategory3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
