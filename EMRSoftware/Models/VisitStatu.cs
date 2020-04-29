namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VisitStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VisitStatu()
        {
            Visitations = new HashSet<Visitation>();
        }

        [Key]
        [StringLength(50)]
        public string VisitStatusID { get; set; }

        [Required]
        [StringLength(70)]
        public string VisitStatusName { get; set; }

        [StringLength(50)]
        public string VisitStatus1 { get; set; }

        [StringLength(50)]
        public string VisitStatus2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
