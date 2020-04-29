namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitType")]
    public partial class VisitType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VisitType()
        {
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string VisitTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string VisitTypeName { get; set; }

        [StringLength(50)]
        public string VisitType1 { get; set; }

        [StringLength(50)]
        public string VisitType2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
