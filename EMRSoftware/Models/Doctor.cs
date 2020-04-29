namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Doctor")]
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string DoctorID { get; set; }

        [Required]
        [StringLength(50)]
        public string DoctorName { get; set; }

        [Required]
        [StringLength(50)]
        public string SpecialtyID { get; set; }

        [StringLength(50)]
        public string Doctor1 { get; set; }

        [StringLength(50)]
        public string Doctor2 { get; set; }

        [StringLength(50)]
        public string Doctor3 { get; set; }

        public virtual Specialty Specialty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
