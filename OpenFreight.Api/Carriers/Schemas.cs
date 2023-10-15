using GraphQL.Types;

namespace OpenFreight.Api.Carriers;

public class CarrierSchema : Schema
{
    public CarrierSchema(IServiceProvider provider, CarrierQuery carrierQuery, CarrierMutation carrierMutation) : base(provider)
    {
        Query = carrierQuery;
        Mutation = carrierMutation;
    }
}