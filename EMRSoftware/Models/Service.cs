namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Service
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TreamentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ConsultReviewID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string VisitationID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string UnitCost { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Qty { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string FinalAmt { get; set; }

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
        public string Service1 { get; set; }

        [StringLength(10)]
        public string Service2 { get; set; }

        [StringLength(10)]
        public string Service3 { get; set; }

        [StringLength(10)]
        public string Service4 { get; set; }

        [StringLength(10)]
        public string Service5 { get; set; }

        public virtual ConsultReview ConsultReview { get; set; }

        public virtual Treatment Treatment { get; set; }

        public virtual Visitation Visitation { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }
    }
}
