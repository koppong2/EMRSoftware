namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgeGroup")]
    public partial class AgeGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AgeGroup()
        {
            CorporateBills = new HashSet<CorporateBill>();
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string AgeGroupID { get; set; }

        [Required]
        [StringLength(70)]
        public string AgeGroupName { get; set; }

        [StringLength(50)]
        public string AgeGroup1 { get; set; }

        [StringLength(50)]
        public string AgeGroup2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
