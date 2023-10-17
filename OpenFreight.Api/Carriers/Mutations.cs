using GraphQL;
using GraphQL.Types;
using OpenFreight.Carriers.Data.Context;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Api.Carriers
{
    public class CarrierMutation : ObjectGraphType
    {
        public CarrierMutation()
        {
            Field<CarrierType>("createCarrier")
                .Argument<NonNullGraphType<CreateCarrierInputType>>("carrier", "Carrier to create")
                .Resolve(context => {
                    if (context.RequestServices is null) 
                    {
                        throw new ArgumentNullException(nameof(context.RequestServices));
                    }
                    var dbcontext = context.RequestServices.GetRequiredService<CarrierDbContext>();
                    var carrierModel = context.GetArgument<CarrierModel>("carrier");
                    dbcontext.Carriers.Add(carrierModel);
                    dbcontext.SaveChanges();
                    return carrierModel;
                });
        }
    }
}