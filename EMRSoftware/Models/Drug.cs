namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Drug
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drug()
        {
            DrugSaleItems = new HashSet<DrugSaleItem>();
            IncomingDrugItems = new HashSet<IncomingDrugItem>();
        }

        [StringLength(50)]
        public string DrugID { get; set; }

        [Required]
        [StringLength(100)]
        public string DrugName { get; set; }

        [Required]
        [StringLength(50)]
        public string DrugCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string DrugTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitCost { get; set; }

        [StringLength(50)]
        public string Drug1 { get; set; }

        [StringLength(50)]
        public string Drug2 { get; set; }

        [StringLength(50)]
        public string Drug3 { get; set; }

        [StringLength(50)]
        public string Drug4 { get; set; }

        [StringLength(50)]
        public string Drug5 { get; set; }

        public virtual DrugCategory DrugCategory { get; set; }

        public virtual DrugType DrugType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSaleItem> DrugSaleItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncomingDrugItem> IncomingDrugItems { get; set; }
    }
}
