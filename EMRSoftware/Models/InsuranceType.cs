namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InsuranceType")]
    public partial class InsuranceType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InsuranceType()
        {
            CorporateBills = new HashSet<CorporateBill>();
            DrugSaleItems = new HashSet<DrugSaleItem>();
            PatientBills = new HashSet<PatientBill>();
            Sponsors = new HashSet<Sponsor>();
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string InsuranceTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string InsuranceTypeName { get; set; }

        [Required]
        [StringLength(50)]
        public string InsuranceValID { get; set; }

        [StringLength(50)]
        public string InsuranceType1 { get; set; }

        [StringLength(50)]
        public string InsuranceType2 { get; set; }

        [StringLength(50)]
        public string InsuranceType3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSaleItem> DrugSaleItems { get; set; }

        public virtual InsuranceVal InsuranceVal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sponsor> Sponsors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
