namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Consultation")]
    public partial class Consultation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Consultation()
        {
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string ConsultationID { get; set; }

        [Required]
        [StringLength(100)]
        public string ConsultationName { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationCost { get; set; }

        [Required]
        [StringLength(50)]
        public string ReviewCost { get; set; }

        [Required]
        [StringLength(50)]
        public string ConsultationCost { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusID { get; set; }

        [Required]
        [StringLength(50)]
        public string SpecialtyID { get; set; }

        [StringLength(50)]
        public string Consultation2 { get; set; }

        [StringLength(50)]
        public string Consultation3 { get; set; }

        [StringLength(50)]
        public string Consultation4 { get; set; }

        [StringLength(50)]
        public string Consultation5 { get; set; }

        public virtual Specialty Specialty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
