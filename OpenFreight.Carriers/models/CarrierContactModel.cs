using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFreight.Carriers.Models
{
    [Table("CarrierContacts", Schema = "carriers")]
    public class CarrierContactModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [Phone]
        public required string Phone { get; set; }

        [Phone]
        public required string Fax { get; set; }

        [Phone]
        public required string Mobile { get; set; }

        [StringLength(250)]
        public required string Notes { get; set; }

        [Required]
        public Guid CarrierID { get; set; }

        [ForeignKey("CarrierID")]
        public virtual required CarrierModel Carrier { get; set; }
    }
}
