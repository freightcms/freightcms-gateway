namespace OpenFreight.Carriers.Models
{
    public class CarrierModel
    {
        public Guid ID { get; set; }

        public required string Name { get; set; }

        public bool IsActive { get; set; } = false;

        public ICollection<CarrierInsuranceModel> Insurance { get; set; } = new List<CarrierInsuranceModel>();

        public ICollection<CarrierContactModel> Contacts { get; set; } = new List<CarrierContactModel>();

        public ICollection<CarrierIdentifyingCode> IdentifyingCodes { get; set; } = new List<CarrierIdentifyingCode>();
    }
}