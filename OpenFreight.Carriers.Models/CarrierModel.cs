using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFreight.Carriers.Models
{
    public class CarrierModel
    {
        public Guid ID { get; set; }

        public required string Name { get; set; }

        public bool IsActive { get; set; } = false;

        public virtual IEnumerable<CarrierInsuranceModel> Insurance { get; set; } = new List<CarrierInsuranceModel>();

        public virtual IEnumerable<CarrierContactModel> Contacts { get; set; } = new List<CarrierContactModel>();

        public virtual IEnumerable<CarrierIdentifyingCode> IdentifyingCodes { get; set; } = new List<CarrierIdentifyingCode>();
    }
}