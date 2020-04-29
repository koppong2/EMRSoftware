namespace EMRSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            BillingGroups = new HashSet<BillingGroup>();
            ConsultReviews = new HashSet<ConsultReview>();
            CorporateBills = new HashSet<CorporateBill>();
            DrugSales = new HashSet<DrugSale>();
            Diagnosis = new HashSet<Diagnosi>();
            DrugSaleItems = new HashSet<DrugSaleItem>();
            PatientBills = new HashSet<PatientBill>();
            Visitations = new HashSet<Visitation>();
        }

        [StringLength(50)]
        public string PatientID { get; set; }

        [Required]
        [StringLength(100)]
        public string PatientName { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string ResidentialAddress { get; set; }

        [StringLength(100)]
        public string postalAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public DateTime dob { get; set; }

        public DateTime DateOfRegistration { get; set; }

        [Required]
        [StringLength(100)]
        public string NextOfKinName { get; set; }

        [Required]
        [StringLength(100)]
        public string NextOfKinAdd { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(50)]
        public string GenderID { get; set; }

        [StringLength(50)]
        public string Age { get; set; }

        [StringLength(50)]
        public string Patient2 { get; set; }

        [StringLength(50)]
        public string Patient3 { get; set; }

        [StringLength(50)]
        public string Patient4 { get; set; }

        [StringLength(50)]
        public string Patient5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillingGroup> BillingGroups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultReview> ConsultReviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorporateBill> CorporateBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSale> DrugSales { get; set; }

        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnosi> Diagnosis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugSaleItem> DrugSaleItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientBill> PatientBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
