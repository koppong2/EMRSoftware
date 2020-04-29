namespace EMRSoftware.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EMRSoftwareModel : DbContext
    {
        public EMRSoftwareModel()
            : base("name=EMRContext")
        {
        }

        public virtual DbSet<AgeGroup> AgeGroups { get; set; }
        public virtual DbSet<BillingDay> BillingDays { get; set; }
        public virtual DbSet<BillingGroup> BillingGroups { get; set; }
        public virtual DbSet<BillingMonth> BillingMonths { get; set; }
        public virtual DbSet<BillingYear> BillingYears { get; set; }
        public virtual DbSet<Consultation> Consultations { get; set; }
        public virtual DbSet<ConsultReview> ConsultReviews { get; set; }
        public virtual DbSet<CorpBillStatu> CorpBillStatus { get; set; }
        public virtual DbSet<CorporateBill> CorporateBills { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<DiseaseCategory> DiseaseCategories { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DrugCategory> DrugCategories { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<DrugSale> DrugSales { get; set; }
        public virtual DbSet<DrugType> DrugTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<IncomingDrug> IncomingDrugs { get; set; }
        public virtual DbSet<IncomingItem> IncomingItems { get; set; }
        public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }
        public virtual DbSet<InsuranceVal> InsuranceVals { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientBill> PatientBills { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ReceiptStatu> ReceiptStatus { get; set; }
        public virtual DbSet<ReceiptType> ReceiptTypes { get; set; }
        public virtual DbSet<Refund> Refunds { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Relation> Relations { get; set; }
        public virtual DbSet<RevenueCenter> RevenueCenters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }
        public virtual DbSet<SponsorCategory> SponsorCategories { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<SubSponsor> SubSponsors { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<VisitStatu> VisitStatus { get; set; }
        public virtual DbSet<VisitType> VisitTypes { get; set; }
        public virtual DbSet<WorkingDay> WorkingDays { get; set; }
        public virtual DbSet<WorkingMonth> WorkingMonths { get; set; }
        public virtual DbSet<WorkingYear> WorkingYears { get; set; }
        public virtual DbSet<Diagnosi> Diagnosis { get; set; }
        public virtual DbSet<DrugSaleItem> DrugSaleItems { get; set; }
        public virtual DbSet<IncomingDrugItem> IncomingDrugItems { get; set; }
        public virtual DbSet<IncomingItemsDetail> IncomingItemsDetails { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeGroup>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.AgeGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BillingDay>()
                .HasMany(e => e.CorporateBills)
                .WithRequired(e => e.BillingDay)
                .WillCascadeOnDelete(false);

       /**     modelBuilder.Entity<BillingGroup>()
                .HasOptional(e => e.BillingGroup11)
                .WithRequired(e => e.BillingGroup6);
    **/
            modelBuilder.Entity<BillingGroup>()
                .HasMany(e => e.CorporateBills)
                .WithRequired(e => e.BillingGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BillingGroup>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.BillingGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BillingMonth>()
                .HasMany(e => e.CorporateBills)
                .WithRequired(e => e.BillingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BillingYear>()
                .HasMany(e => e.CorporateBills)
                .WithRequired(e => e.BillingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Consultation>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.Consultation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConsultReview>()
                .HasOptional(e => e.ConsultReview11)
                .WithRequired(e => e.ConsultReview6);

            modelBuilder.Entity<ConsultReview>()
                .HasMany(e => e.Diagnosis)
                .WithRequired(e => e.ConsultReview)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConsultReview>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.ConsultReview)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Disease>()
                .HasMany(e => e.Diagnosis)
                .WithRequired(e => e.Disease)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiseaseCategory>()
                .HasMany(e => e.Diseases)
                .WithRequired(e => e.DiseaseCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DrugCategory>()
                .Property(e => e.DrugCategory1)
                .IsFixedLength();

            modelBuilder.Entity<DrugCategory>()
                .Property(e => e.DrugCategory2)
                .IsFixedLength();

            modelBuilder.Entity<DrugCategory>()
                .Property(e => e.DrugCategory3)
                .IsFixedLength();

            modelBuilder.Entity<DrugCategory>()
                .Property(e => e.DrugCategory4)
                .IsFixedLength();

            modelBuilder.Entity<DrugCategory>()
                .Property(e => e.DrugCategory5)
                .IsFixedLength();

            modelBuilder.Entity<DrugCategory>()
                .HasMany(e => e.Drugs)
                .WithRequired(e => e.DrugCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Drug>()
                .HasMany(e => e.DrugSaleItems)
                .WithRequired(e => e.Drug)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Drug>()
                .HasMany(e => e.IncomingDrugItems)
                .WithRequired(e => e.Drug)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DrugSale>()
                .HasMany(e => e.DrugSaleItems)
                .WithRequired(e => e.DrugSale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DrugType>()
                .HasMany(e => e.Drugs)
                .WithRequired(e => e.DrugType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Patients)
                .WithRequired(e => e.Gender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IncomingDrug>()
                .HasMany(e => e.IncomingDrugItems)
                .WithRequired(e => e.IncomingDrug)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IncomingItem>()
                .HasMany(e => e.IncomingItemsDetails)
                .WithRequired(e => e.IncomingItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceType>()
                .HasMany(e => e.DrugSaleItems)
                .WithRequired(e => e.InsuranceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceType>()
                .HasMany(e => e.Sponsors)
                .WithRequired(e => e.InsuranceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceType>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.InsuranceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceVal>()
                .HasMany(e => e.InsuranceTypes)
                .WithRequired(e => e.InsuranceVal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceVal>()
                .HasMany(e => e.DrugSaleItems)
                .WithRequired(e => e.InsuranceVal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InsuranceVal>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.InsuranceVal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCategory>()
                .HasOptional(e => e.ItemCategory11)
                .WithRequired(e => e.ItemCategory3);

            modelBuilder.Entity<ItemCategory>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.ItemCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.IncomingItemsDetails)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.BillingGroups)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.ConsultReviews)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.CorporateBills)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.DrugSales)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Diagnosis)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.DrugSaleItems)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ReceiptAmount)
                .IsFixedLength();

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ReceiptAmt1)
                .IsFixedLength();

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ReceiptAmt2)
                .IsFixedLength();

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ReceiptAmt3)
                .IsFixedLength();

            modelBuilder.Entity<Receipt>()
                .Property(e => e.BankName)
                .IsFixedLength();

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ChequeNo)
                .IsFixedLength();

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ChequeDetails)
                .IsFixedLength();

            modelBuilder.Entity<Receipt>()
                .Property(e => e.Purpose)
                .IsFixedLength();

            modelBuilder.Entity<Receipt>()
                .HasMany(e => e.Refunds)
                .WithRequired(e => e.Receipt)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiptStatu>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.ReceiptStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiptType>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.ReceiptType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Sponsors)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.SubSponsors)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Relation>()
                .HasMany(e => e.BillingGroups)
                .WithRequired(e => e.Relation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RevenueCenter>()
                .HasMany(e => e.ConsultReviews)
                .WithRequired(e => e.RevenueCenter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RevenueCenter>()
                .HasMany(e => e.DrugSales)
                .WithRequired(e => e.RevenueCenter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RevenueCenter>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.RevenueCenter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.SystemUsers)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialty>()
                .HasMany(e => e.Consultations)
                .WithRequired(e => e.Specialty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialty>()
                .HasMany(e => e.Doctors)
                .WithRequired(e => e.Specialty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialty>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.Specialty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sponsor>()
                .HasMany(e => e.BillingGroups)
                .WithRequired(e => e.Sponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sponsor>()
                .HasMany(e => e.ConsultReviews)
                .WithRequired(e => e.Sponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sponsor>()
                .HasMany(e => e.DrugSales)
                .WithRequired(e => e.Sponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sponsor>()
                .HasMany(e => e.Diagnosis)
                .WithRequired(e => e.Sponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sponsor>()
                .HasMany(e => e.SponsorCategories)
                .WithRequired(e => e.Sponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sponsor>()
                .HasMany(e => e.SubSponsors)
                .WithRequired(e => e.Sponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sponsor>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.Sponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.SystemUsers)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.BillingGroups)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Sponsors)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.SubSponsors)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.SystemUsers)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Treatments)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubSponsor>()
                .HasMany(e => e.BillingGroups)
                .WithRequired(e => e.SubSponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubSponsor>()
                .HasMany(e => e.SponsorCategories)
                .WithRequired(e => e.SubSponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubSponsor>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.SubSponsor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.IncomingDrugs)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.IncomingItems)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table>()
                .HasMany(e => e.CorporateBills)
                .WithRequired(e => e.Table)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Treatment1)
                .IsFixedLength();

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Treatment2)
                .IsFixedLength();

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Treatment3)
                .IsFixedLength();

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Treatment4)
                .IsFixedLength();

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Treatment5)
                .IsFixedLength();

            modelBuilder.Entity<Treatment>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.Treatment)
                .HasForeignKey(e => e.TreamentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Visitation>()
                .HasMany(e => e.ConsultReviews)
                .WithRequired(e => e.Visitation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Visitation>()
                .HasMany(e => e.CorporateBills)
                .WithRequired(e => e.Visitation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Visitation>()
                .HasMany(e => e.DrugSales)
                .WithRequired(e => e.Visitation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Visitation>()
                .HasMany(e => e.Diagnosis)
                .WithRequired(e => e.Visitation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Visitation>()
                .HasMany(e => e.DrugSaleItems)
                .WithRequired(e => e.Visitation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Visitation>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.Visitation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VisitStatu>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.VisitStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VisitType>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.VisitType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.ConsultReviews)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.IncomingDrugs)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.IncomingItems)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.Diagnosis)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.DrugSaleItems)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.IncomingDrugItems)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.IncomingItemsDetails)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingDay>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.WorkingDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.ConsultReviews)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.IncomingDrugs)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.IncomingItems)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.Diagnosis)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.DrugSaleItems)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.IncomingDrugItems)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.IncomingItemsDetails)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingMonth>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.WorkingMonth)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.ConsultReviews)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.IncomingDrugs)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.IncomingItems)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.Visitations)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.Diagnosis)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.DrugSaleItems)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.IncomingDrugItems)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.IncomingItemsDetails)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkingYear>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.WorkingYear)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IncomingItemsDetail>()
                .Property(e => e.IncomingItemsDetail1)
                .IsFixedLength();

            modelBuilder.Entity<IncomingItemsDetail>()
                .Property(e => e.IncomingItemsDetail2)
                .IsFixedLength();

            modelBuilder.Entity<IncomingItemsDetail>()
                .Property(e => e.IncomingItemsDetail3)
                .IsFixedLength();

            modelBuilder.Entity<IncomingItemsDetail>()
                .Property(e => e.IncomingItemsDetail4)
                .IsFixedLength();

            modelBuilder.Entity<IncomingItemsDetail>()
                .Property(e => e.IncomingItemsDetail5)
                .IsFixedLength();

            modelBuilder.Entity<Service>()
                .Property(e => e.Service1)
                .IsFixedLength();

            modelBuilder.Entity<Service>()
                .Property(e => e.Service2)
                .IsFixedLength();

            modelBuilder.Entity<Service>()
                .Property(e => e.Service3)
                .IsFixedLength();

            modelBuilder.Entity<Service>()
                .Property(e => e.Service4)
                .IsFixedLength();

            modelBuilder.Entity<Service>()
                .Property(e => e.Service5)
                .IsFixedLength();
        }
    }
}
