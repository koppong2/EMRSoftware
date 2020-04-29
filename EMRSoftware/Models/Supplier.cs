namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            IncomingDrugs = new HashSet<IncomingDrug>();
            IncomingItems = new HashSet<IncomingItem>();
        }

        [StringLength(50)]
        public string SupplierID { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusID { get; set; }

        [Required]
        [StringLength(100)]
        public string location { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(100)]
        public string postalAddress { get; set; }

        [StringLength(50)]
        public string supplier1 { get; set; }

        [StringLength(50)]
        public string supplier2 { get; set; }

        [StringLength(50)]
        public string supplier3 { get; set; }

        [StringLength(50)]
        public string supplier4 { get; set; }

        [StringLength(50)]
        public string supplier5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncomingDrug> IncomingDrugs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncomingItem> IncomingItems { get; set; }

        public virtual Status Status { get; set; }
    }
}
