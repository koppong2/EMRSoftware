namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IncomingDrug")]
    public partial class IncomingDrug
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IncomingDrug()
        {
            IncomingDrugItems = new HashSet<IncomingDrugItem>();
        }

        [StringLength(50)]
        public string IncomingDrugID { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierID { get; set; }

        public DateTime IncomingDrugDate { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkingYearID { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkingMonthID { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkingDayID { get; set; }

        [StringLength(50)]
        public string IncomingDrug1 { get; set; }

        [StringLength(50)]
        public string IncomingDrug2 { get; set; }

        [StringLength(50)]
        public string IncomingDrug3 { get; set; }

        [StringLength(50)]
        public string IncomingDrug4 { get; set; }

        [StringLength(50)]
        public string IncomingDrug5 { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IncomingDrugItem> IncomingDrugItems { get; set; }
    }
}
