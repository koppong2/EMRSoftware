namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Treatment")]
    public partial class Treatment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Treatment()
        {
            Services = new HashSet<Service>();
        }

        [StringLength(50)]
        public string TreatmentID { get; set; }

        [Required]
        [StringLength(100)]
        public string TreatmentName { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitCost { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusID { get; set; }

        [StringLength(10)]
        public string Treatment1 { get; set; }

        [StringLength(10)]
        public string Treatment2 { get; set; }

        [StringLength(10)]
        public string Treatment3 { get; set; }

        [StringLength(10)]
        public string Treatment4 { get; set; }

        [StringLength(10)]
        public string Treatment5 { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Services { get; set; }
    }
}
