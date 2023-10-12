using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFreight.Carriers.Models
{
    public class CarrierModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = false;

        public virtual IEnumerable<CarrierContactModel> Contacts { get; set; } = new List<CarrierContactModel>();

        public virtual IEnumerable<CarrierIdentifyingCode> IdentifyingCodes { get; set; } = new List<CarrierIdentifyingCode>();
    }
}