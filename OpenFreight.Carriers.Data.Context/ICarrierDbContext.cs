using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Carriers.Data.Context
{
    /// <summary>
    /// Represents interface for fetching database records using entity framework core. 
    /// </summary>
    public class CarrierDbContext : DbContext 
    {
        public DbSet<CarrierModel> Carriers { get; set; }
        public DbSet<CarrierContactModel> CarrierServices { get; set; }
        public DbSet<CarrierIdentifyingCode> IdentifyingCodes { get; set; }
        public DbSet<CarrierInsuranceModel> CarrierInsurance { get; set; }
    }
}