using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFreight.Carriers.Models
{
    public class CarrierContactModel
    {
        public Guid ID { get; set; }

        public required string FullName { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public string? Fax { get; set; }

        public string? Mobile { get; set; }

        public string? Notes { get; set; }

        public Guid CarrierID { get; set; }

        public CarrierModel? Carrier { get; set; }
    }
}
