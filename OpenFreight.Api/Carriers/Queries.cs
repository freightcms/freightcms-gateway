using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers.Data.Context;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Api.Carriers;

public class CarrierQuery : ObjectGraphType
{
    public CarrierQuery()
    {
        Field<ListGraphType<CarrierType>>("carriers")
            .ResolveAsync(async context => {
                if (context.RequestServices is null) 
                {
                    throw new ArgumentNullException(nameof(context.RequestServices));
                }

                var carrierDbContext = context.RequestServices.GetRequiredService<CarrierDbContext>();
                return await carrierDbContext.Carriers.ToListAsync();
            });
    }
}