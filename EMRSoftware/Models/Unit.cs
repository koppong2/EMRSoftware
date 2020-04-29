namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Unit")]
    public partial class Unit
    {
        [StringLength(50)]
        public string UnitId { get; set; }

        [Required]
        [StringLength(100)]
        public string UnitName { get; set; }

        [StringLength(50)]
        public string Unit1 { get; set; }

        [StringLength(50)]
        public string Unit2 { get; set; }

        [StringLength(50)]
        public string Unit3 { get; set; }
    }
}
