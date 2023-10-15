using GraphQL;
using GraphQL.Types;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Api.Carriers
{
    public class CarrierMutation : ObjectGraphType
    {
        public CarrierMutation()
        {   
            Field<CreateCarrerInputType>("createCarrier")
                .Argument<NonNullGraphType<CreateCarrerInputType>>("carrier", "Carrier to create")
                .Resolve(context => {
                    var carrierInput = context.GetArgument<CreateCarrerInputType>("carrier");
                    if (carrierInput == null)
                    {
                        context.Errors.Add(new ExecutionError("Carrier input is null"));
                        return null;
                    }
                    var carrierDto = new CarrierModel
                    {
                        Name = carrierInput.Field<string>("carrierName").ToString(),
                    };
                    
                    return carrierDto;
                });
        }
    }
}