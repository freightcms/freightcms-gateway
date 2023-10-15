using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers;
using OpenFreight.Carriers.Data.Context;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Api.Carriers;

public class CarrierType : ObjectGraphType<CarrierModel>
{
    public CarrierType()
    {
        Field(x => x.ID);
        Field(x => x.Name).Description("Name of the Carrier");
    }
} 

public class CarrierQuery : ObjectGraphType
{
    public CarrierQuery(CarrierDbContext carrierDbContext)
    {
        Field<ListGraphType<CarrierType>>("carriers")
            .ResolveAsync(async context => await carrierDbContext.Carriers.ToListAsync());
    }
}

public class CarrierMutation : ObjectGraphType
{

}

public class CarrierSchema : Schema
{
    public CarrierSchema(IServiceProvider provider, CarrierQuery carrierQuery, CarrierMutation carrierMutation) : base(provider)
    {
        Query = carrierQuery;
        Mutation = carrierMutation;
    }
}