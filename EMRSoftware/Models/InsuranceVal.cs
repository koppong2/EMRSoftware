namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InsuranceVal")]
    public partial class InsuranceVal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InsuranceVal()
        {
            InsuranceTypes = new HashSet<InsuranceType>();
            DrugSaleItems = new HashSet<DrugSaleItem>();
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string InsuranceValID { get; set; }

        [Required]
        [StringLength(100)]
        public string InsuranceValName { get; set; }

        [StringLength(50)]
        public string InsuranceVal1 { get; set; }

        [StringLength(50)]
        public string InsuranceVal2 { get; set; }

        [StringLength(50)]
        public string InsuranceVal3 { get; set; }

        [StringLength(50)]
        public string InsuranceVal4 { get; set; }

        [StringLength(50)]
        public string InsuranceVal5 { get; set; }

        [Required]
        [StringLength(50)]
        public string Visitation { get; set; }

        [Required]
        [StringLength(50)]
        public string Treatment { get; set; }

        [Required]
        [StringLength(50)]
        public string DrugSale { get; set; }

        [Required]
        [StringLength(50)]
        public string Admission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InsuranceType> InsuranceTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSaleItem> DrugSaleItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
