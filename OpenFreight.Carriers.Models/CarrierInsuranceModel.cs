using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFreight.Carriers.Models
{
    [Table("CarrierInsurance", Schema = "carriers")]
    public class CarrierInsuranceModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Guid CarrierID { get; set; }
        
        [Required]
        public required string InsuranceType { get; set; }
        
        [Required]
        public SqlMoney InsuranceAmount { get; set; }

        public SqlMoney InsuranceDeductible { get; set; }
        
        [StringLength(250)]
        public required string InsuranceNotes { get; set; }
        
        [Required]
        [StringLength(50)]
        public required string PolicyNumber { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string PolicyHolder { get; set; }
        
        [Required]
        [StringLength(250)]
        public required string PolicyHolderAddress1 { get; set; }

        [Required]
        [StringLength(250)]
        public required string PolicyHolderAddress3 { get; set; }

        [Required]
        [StringLength(250)]
        public required string PolicyHolderAddress2 { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string PolicyHolderCity { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string PolicyHolderStateOrProvince { get; set; }
        
        [Required]
        [StringLength(20)]
        public required string PolicyHolderZip { get; set; }

        [Required]
        [StringLength(100)]
        public required string PolicyHolderCountry { get; set; }

        [Required]
        [Phone]
        public required string PolicyHolderPhone { get; set; }

        [StringLength(100)]
        public required string PolicyHolderFax { get; set; }

        [Required]
        [EmailAddress]
        public required string PolicyHolderEmail { get; set; }

        [StringLength(100)]
        public required string PolicyHolderNotes { get; set; }


        [ForeignKey("CarrierID")]
        public virtual required CarrierModel Carrier { get; set; }
    }
}