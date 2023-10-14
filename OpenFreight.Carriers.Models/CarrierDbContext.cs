using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Carriers
{
    public class CarrierDbContext : DbContext
    {
        public virtual required DbSet<CarrierModel> Carriers { get; set; }
        public virtual required DbSet<CarrierIdentifyingCode> CarrierIdentifyingCodes { get; set; }
        public virtual required DbSet<CarrierContactModel> CarrierContacts { get; set; }
        public virtual required DbSet<CarrierInsuranceModel> CarrierInsurance { get; set; }

        public CarrierDbContext(DbContextOptions<CarrierDbContext> options) : base(options)
        {
        }
    }
}
