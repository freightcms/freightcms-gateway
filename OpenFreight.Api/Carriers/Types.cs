using GraphQL;
using GraphQL.Types;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Api.Carriers
{
    public class CreateCarrierInputType : InputObjectGraphType<CarrierModel>
    {
        public CreateCarrierInputType()
        {
            Name = "CreateCarrierInput";
            Field(x => x.Name).Description("Name of the Carrier").Name("carrierName");
        }
    }

    public class CarrierType : ObjectGraphType<CarrierModel>
    {
        public CarrierType()
        {
            Field(x => x.ID).Description("ID of the Carrier").Name("id");
            Field(x => x.Name).Description("Name of the Carrier").Name("carrierName");
        }
    } 
}