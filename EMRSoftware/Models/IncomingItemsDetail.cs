namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IncomingItemsDetail")]
    public partial class IncomingItemsDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string IncomingItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ItemID { get; set; }

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

        [StringLength(10)]
        public string IncomingItemsDetail1 { get; set; }

        [StringLength(10)]
        public string IncomingItemsDetail2 { get; set; }

        [StringLength(10)]
        public string IncomingItemsDetail3 { get; set; }

        [StringLength(10)]
        public string IncomingItemsDetail4 { get; set; }

        [StringLength(10)]
        public string IncomingItemsDetail5 { get; set; }

        public virtual IncomingItem IncomingItem { get; set; }

        public virtual Item Item { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }
    }
}
