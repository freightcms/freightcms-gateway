using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Carriers.Data.Context
{
    /// <summary>
    /// Represents interface for fetching database records using entity framework core. 
    /// </summary>
    public class CarrierDbContext : DbContext 
    {
        public DbSet<CarrierModel> Carriers { get; set; }
        public DbSet<CarrierContactModel> CarrierServices { get; set; }
        public DbSet<CarrierIdentifyingCode> IdentifyingCodes { get; set; }
        public DbSet<CarrierInsuranceModel> CarrierInsurance { get; set; }

        public CarrierDbContext(DbContextOptions<CarrierDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarrierModel>(config => {
                config.Property(x => x.ID)
                    .HasColumnName("ID")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                config.Property(x => x.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.IsActive)
                    .HasDefaultValue(false);
                
                config.HasMany(x => x.IdentifyingCodes).WithOne(x => x.Carrier).HasForeignKey(x => x.CarrierID).OnDelete(DeleteBehavior.Cascade);
                config.HasMany(x => x.Contacts).WithOne(x => x.Carrier).HasForeignKey(x => x.CarrierID).OnDelete(DeleteBehavior.Cascade);
                config.HasMany(x => x.Insurance).WithOne(x => x.Carrier).HasForeignKey(x => x.CarrierID).OnDelete(DeleteBehavior.Cascade);
                config.ToTable("Carriers", "carriers");
                config.HasIndex(x => x.Name).IsUnique();
            });

            modelBuilder.Entity<CarrierContactModel>(config => {
                config.Property(x => x.ID)
                    .HasColumnName("ID")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                config.Property(x => x.CarrierID)
                    .HasColumnName("CarrierID")
                    .IsRequired();
                config.Property(x => x.FullName)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.Email)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.Phone)
                    .HasColumnName("Phone")
                    .IsRequired()
                    .HasMaxLength(20);
                config.Property(x => x.Notes)
                    .HasColumnName("Notes")
                    .HasMaxLength(500);
                config.Property(x => x.Fax)
                    .HasColumnName("Fax")
                    .HasMaxLength(20);
                config.Property(x => x.Mobile)
                    .HasColumnName("Mobile")
                    .HasMaxLength(20);
                config.HasOne(x => x.Carrier).WithMany(x => x.Contacts).HasForeignKey(x => x.CarrierID);
                config.ToTable("CarrierContacts", "carriers");
            });

            modelBuilder.Entity<CarrierInsuranceModel>(config => {
                config.ToTable("CarrierInsurance", "carriers");
                config.Property(x => x.ID)
                    .HasColumnName("ID")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                config.Property(x => x.CarrierID)
                    .HasColumnName("CarrierID")
                    .IsRequired();
                config.Property(x => x.InsuranceNotes)
                    .HasColumnName("InsuranceNotes")
                    .HasMaxLength(500);
                config.Property(x => x.InsuranceType)
                    .HasColumnName("InsuranceType")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.InsuranceDeductible)
                    .HasColumnName("InsuranceDeductible")
                    .IsRequired()
                    .HasPrecision(2)
                    .HasColumnType("decimal(18,2)");
                config.Property(x => x.InsuranceAmount)
                    .HasColumnName("InsuranceAmount")
                    .IsRequired()
                    .HasPrecision(2)
                    .HasColumnType("decimal(18,2)");
                config.Property(x => x.PolicyHolder)
                    .HasColumnName("PolicyHolder")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.PolicyNumber)
                    .HasColumnName("PolicyNumber")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.PolicyExpiration)
                    .HasColumnName("PolicyExpiration")
                    .IsRequired();
                config.Property(x => x.PolicyHolderAddress1)
                    .HasColumnName("PolicyHolderAddress1")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.PolicyHolderAddress2)
                    .HasColumnName("PolicyHolderAddress2")
                    .HasMaxLength(100);
                config.Property(x => x.PolicyHolderAddress3)
                    .HasColumnName("PolicyHolderAddress3")
                    .HasMaxLength(100);
                config.Property(x => x.PolicyHolderCity)
                    .HasColumnName("PolicyHolderCity")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.PolicyHolderStateOrProvince)
                    .HasColumnName("PolicyHolderStateOrProvince")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.PolicyHolderZip)
                    .HasColumnName("PolicyHolderZip")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.PolicyHolderCountry)
                    .HasColumnName("PolicyHolderCountry")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.PolicyHolderPhone)
                    .HasColumnName("PolicyHolderPhone")
                    .IsRequired()
                    .HasMaxLength(20);
                config.Property(x => x.PolicyHolderFax)
                    .HasColumnName("PolicyHolderFax")
                    .HasMaxLength(20);
                config.Property(x => x.PolicyHolderEmail)
                    .HasColumnName("PolicyHolderEmail")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.PolicyHolderNotes)
                    .HasColumnName("PolicyHolderNotes")
                    .HasMaxLength(500);
                
                config.HasOne(x => x.Carrier).WithMany(x => x.Insurance).HasForeignKey(x => x.CarrierID);
            });

            modelBuilder.Entity<CarrierIdentifyingCode>(config => {
                config.Property(x => x.ID)
                    .HasColumnName("ID")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
                config.Property(x => x.CarrierID)
                    .HasColumnName("CarrierID")
                    .IsRequired();
                config.Property(x => x.Code)
                    .HasColumnName("Code")
                    .IsRequired()
                    .HasMaxLength(100);
                config.Property(x => x.CodeType)
                    .HasColumnName("CodeType")
                    .IsRequired()
                    .HasMaxLength(100);
                config.HasOne(x => x.Carrier).WithMany(x => x.IdentifyingCodes).HasForeignKey(x => x.CarrierID);
                config.ToTable("CarrierIdentifyingCodes", "carriers");
            });
        }
    }
}