namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CorpBillStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CorpBillStatu()
        {
            CorporateBills = new HashSet<CorporateBill>();
        }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string CorpBillStatusName { get; set; }

        [StringLength(255)]
        public string KeyPrefix { get; set; }

        [Key]
        [StringLength(50)]
        public string CorpBillStatusID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }
    }
}
