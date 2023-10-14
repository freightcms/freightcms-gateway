using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Carriers.Data.Abstract
{
    /// <summary>
    /// Represents interface for fetching database records using entity framework core. 
    /// </summary>
    public interface ICarrierDbContext 
    {
        public DbSet<CarrierModel> Carriers { get; set; }
        public DbSet<CarrierContactModel> CarrierServices { get; set; }
        public DbSet<CarrierIdentifyingCode> IdentifyingCodes { get; set; }
        public DbSet<CarrierInsuranceModel> CarrierInsurance { get; set; }
    }
}