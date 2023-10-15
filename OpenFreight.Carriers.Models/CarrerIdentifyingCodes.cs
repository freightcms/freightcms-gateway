namespace OpenFreight.Carriers.Models
{
    public class CarrierIdentifyingCode
    {
        public Guid ID { get; set; }

        public Guid CarrierID { get; set; }

        public required string CodeType { get; set; }

        public required string Code { get; set; }

        public CarrierModel? Carrier { get; set; }
    }
}