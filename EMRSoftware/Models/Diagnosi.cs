namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Diagnosi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ConsultReviewID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DiseaseID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string VisitationID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string UnitCost { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Qty { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string FinalCost { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string PatientID { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string SponsorID { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string WorkingDayID { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string WorkingMonthID { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(50)]
        public string WorkingYearID { get; set; }

        [StringLength(50)]
        public string Diagnosis1 { get; set; }

        [StringLength(50)]
        public string Diagnosis2 { get; set; }

        [StringLength(50)]
        public string Diagnosis3 { get; set; }

        [StringLength(50)]
        public string Diagnosis4 { get; set; }

        [StringLength(50)]
        public string Diagnosis5 { get; set; }

        public virtual ConsultReview ConsultReview { get; set; }

        public virtual Disease Disease { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Sponsor Sponsor { get; set; }

        public virtual Visitation Visitation { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }
    }
}
