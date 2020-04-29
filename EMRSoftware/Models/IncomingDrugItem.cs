namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IncomingDrugItem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string IncomingDrugID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DrugID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string UnitCost { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Qty { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string FinalAmt { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime EntryDate { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string WorkingYearID { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string WorkingMonthID { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string WorkingDayID { get; set; }

        [StringLength(50)]
        public string IncomingDrugItems1 { get; set; }

        [StringLength(50)]
        public string IncomingDrugItems2 { get; set; }

        [StringLength(50)]
        public string IncomingDrugItems3 { get; set; }

        [StringLength(50)]
        public string IncomingDrugItems4 { get; set; }

        [StringLength(50)]
        public string IncomingDrugItems5 { get; set; }

        public virtual Drug Drug { get; set; }

        public virtual IncomingDrug IncomingDrug { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }
    }
}
