using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFreight.Carriers.Models
{
    [Table("CarrierIdentifyingCodes", Schema = "carriers")]
    public class CarrierIdentifyingCode
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        public Guid CarrierID { get; set; }

        [Required]
        [StringLength(100)]
        public required string CodeType { get; set; }

        [Required]
        [StringLength(100)]
        public required string Code { get; set; }

        [ForeignKey("CarrierID")]
        public required virtual CarrierModel Carrier { get; set; }
    }
}