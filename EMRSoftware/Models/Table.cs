namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table()
        {
            CorporateBills = new HashSet<CorporateBill>();
            PatientBills = new HashSet<PatientBill>();
        }

        [StringLength(50)]
        public string TableID { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        [StringLength(50)]
        public string Table1 { get; set; }

        [StringLength(50)]
        public string Table2 { get; set; }

        [StringLength(50)]
        public string Table3 { get; set; }

        [StringLength(50)]
        public string Table4 { get; set; }

        [StringLength(50)]
        public string Table5 { get; set; }

        [StringLength(50)]
        public string Table6 { get; set; }

        [StringLength(50)]
        public string Table7 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }
    }
}
