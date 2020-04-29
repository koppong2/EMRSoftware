namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Specialty")]
    public partial class Specialty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specialty()
        {
            Consultations = new HashSet<Consultation>();
            Doctors = new HashSet<Doctor>();
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string SpecialtyID { get; set; }

        [Required]
        [StringLength(100)]
        public string SpecialtyName { get; set; }

        [StringLength(50)]
        public string Specialty1 { get; set; }

        [StringLength(50)]
        public string Specialty2 { get; set; }

        [StringLength(50)]
        public string Specialty3 { get; set; }

        [StringLength(50)]
        public string Specialty4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consultation> Consultations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doctor> Doctors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
