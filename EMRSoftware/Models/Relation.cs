namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Relation")]
    public partial class Relation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Relation()
        {
            BillingGroups = new HashSet<BillingGroup>();
        }

        [StringLength(50)]
        public string RelationID { get; set; }

        [Required]
        [StringLength(100)]
        public string RelationName { get; set; }

        [StringLength(50)]
        public string Relation1 { get; set; }

        [StringLength(50)]
        public string Relation2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillingGroup> BillingGroups { get; set; }
    }
}
