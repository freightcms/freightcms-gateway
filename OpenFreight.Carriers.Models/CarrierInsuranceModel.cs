using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFreight.Carriers.Models
{
    public class CarrierInsuranceModel
    {
        public Guid ID { get; set; }
        
        public Guid CarrierID { get; set; }
    
        public required string InsuranceType { get; set; }
        
        public decimal InsuranceAmount { get; set; }

        public decimal InsuranceDeductible { get; set; }
        
        public required string InsuranceNotes { get; set; }
        
        public required string PolicyNumber { get; set; }
        
        public required string PolicyHolder { get; set; }
        
        public required string PolicyHolderAddress1 { get; set; }

        public required string PolicyHolderAddress3 { get; set; }

        public required string PolicyHolderAddress2 { get; set; }
        
        public required string PolicyHolderCity { get; set; }
        
        public required string PolicyHolderStateOrProvince { get; set; }
        
        public required string PolicyHolderZip { get; set; }

        public required string PolicyHolderCountry { get; set; }

        public required string PolicyHolderPhone { get; set; }

        public string? PolicyHolderFax { get; set; }

        public required string PolicyHolderEmail { get; set; }

        public string? PolicyHolderNotes { get; set; }
        public DateTime PolicyExpiration {get; set; }

        public virtual CarrierModel? Carrier { get; set; }
    }
}