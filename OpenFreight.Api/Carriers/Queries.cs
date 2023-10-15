using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers.Data.Context;

namespace OpenFreight.Api.Carriers;

public class CarrierQuery : ObjectGraphType
{
    public CarrierQuery(CarrierDbContext carrierDbContext)
    {
        Field<ListGraphType<CarrierType>>("carriers")
            .ResolveAsync(async context => await carrierDbContext.Carriers.Select(x => new { ID = x.ID, Name = x.Name}).ToListAsync());
    }
}