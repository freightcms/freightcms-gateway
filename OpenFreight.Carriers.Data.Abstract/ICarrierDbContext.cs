using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Carriers.Data.Abstract
{
    /// <summary>
    /// Represents interface for fetching database records using entity framework core. 
    /// </summary>
    /// <example>
    /// using OpenFreight.Carriers.Data.Abstract;
    /// using OpenFreight.Carriers.Models;
    /// 
    /// using ContosoUniversity.Data;
    /// using Microsoft.EntityFrameworkCore;
    /// var builder = WebApplication.CreateBuilder(args);
    ///
    /// builder.Services.AddRazorPages();
builder.Services.AddDbContext<SchoolContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));
    public interface ICarrierDbContext 
    {
        public DbSet<CarrierModel> Carriers { get; set; }
    }
}