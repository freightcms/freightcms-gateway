using OpenFreight.Carriers;
using OpenFreight.Carriers.Data.Context;

namespace OpenFreight.Api.Carriers;

public class CarrierSchema
{
    public static IQueryable<string> Carriers(CarrierDbContext context) => context.Carriers.Select(c => c.Name);
}