namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Refund")]
    public partial class Refund
    {
        [StringLength(50)]
        public string RefundID { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiptID { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiptVal1 { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiptVal3 { get; set; }

        [Required]
        [StringLength(50)]
        public string RefundAmount { get; set; }

        public DateTime RefundDate { get; set; }

        [StringLength(50)]
        public string Refund1 { get; set; }

        [StringLength(50)]
        public string Refund2 { get; set; }

        [StringLength(50)]
        public string Refund3 { get; set; }

        [StringLength(50)]
        public string Refund4 { get; set; }

        [StringLength(50)]
        public string Refund5 { get; set; }

        public DateTime? RefundDate1 { get; set; }

        public DateTime? RefundDate2 { get; set; }

        public DateTime? RefundDate3 { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
