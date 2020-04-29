namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DrugSaleItem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string DrugSaleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DrugID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string VisitationID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string PatientID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string unitCost { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Qty { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string FinalAmt { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string InsuranceTypeID { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string InsuranceValID { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime DispenseDate { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string WorkingYearID { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(50)]
        public string WorkingMonthID { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(50)]
        public string WorkingDayID { get; set; }

        public DateTime? DispenseDate1 { get; set; }

        public DateTime? DispenseDate2 { get; set; }

        public DateTime? DispenseDate3 { get; set; }

        [StringLength(50)]
        public string DrugSaleItems1 { get; set; }

        [StringLength(50)]
        public string DrugSaleItems2 { get; set; }

        [StringLength(50)]
        public string DrugSaleItems3 { get; set; }

        public virtual Drug Drug { get; set; }

        public virtual DrugSale DrugSale { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }

        public virtual InsuranceVal InsuranceVal { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Visitation Visitation { get; set; }

        public virtual WorkingDay WorkingDay { get; set; }

        public virtual WorkingMonth WorkingMonth { get; set; }

        public virtual WorkingYear WorkingYear { get; set; }
    }
}
