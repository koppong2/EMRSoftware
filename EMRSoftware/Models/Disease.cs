namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Disease")]
    public partial class Disease
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disease()
        {
            Diagnosis = new HashSet<Diagnosi>();
        }

        [StringLength(50)]
        public string DiseaseID { get; set; }

        [Required]
        [StringLength(50)]
        public string DiseaseName { get; set; }

        [Required]
        [StringLength(50)]
        public string DiseaseCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusID { get; set; }

        [StringLength(50)]
        public string Disease1 { get; set; }

        [StringLength(50)]
        public string Disease2 { get; set; }

        [StringLength(50)]
        public string Disease3 { get; set; }

        [StringLength(50)]
        public string Disease4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnosi> Diagnosis { get; set; }

        public virtual DiseaseCategory DiseaseCategory { get; set; }
    }
}
