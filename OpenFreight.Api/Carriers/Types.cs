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
            Field(x => x.IsActive).Description("Flag for inidicating if the carrier is active").Name("isActive");
            Field(x => x.Insurance, type: typeof(ListGraphType<CarrierInsuranceType>)).Description("Insurance information for the carrier").Name("insurance");
        }
    }

    public class CarrierInsuranceType : ObjectGraphType<CarrierInsuranceModel>
    {
        public CarrierInsuranceType()
        {
            Field(x => x.ID).Description("ID of the Insurance").Name("id");
            Field(x => x.PolicyNumber).Description("Policy number").Name("policyNumber");
            Field(x => x.PolicyExpiration).Description("Expiration date for the policy").Name("policyExpiration");
            Field(x => x.InsuranceAmount).Description("Amount of insurance").Name("insuranceAmount");
            Field(x => x.InsuranceDeductible).Description("Deductible for the insurance").Name("insuranceDeductible");
            Field(x => x.InsuranceType).Description("Type of insurance").Name("insuranceType");
            Field(x => x.InsuranceNotes).Description("Notes for the insurance").Name("insuranceNotes");
            // policy holder information
            Field(x => x.PolicyHolderAddress1).Description("Address line 1 for the policy holder").Name("policyHolderAddress1");
            Field(x => x.PolicyHolderAddress2).Description("Address line 2 for the policy holder").Name("policyHolderAddress2");
            Field(x => x.PolicyHolderAddress3).Description("Address line 3 for the policy holder").Name("policyHolderAddress3");
            Field(x => x.PolicyHolder).Description("Name of the policy holder").Name("policyHolder");
            Field(x => x.PolicyHolderCity).Description("City of the policy holder").Name("policyHolderCity");
            Field(x => x.PolicyHolderCountry).Description("Country of the policy holder").Name("policyHolderCountry");
            Field(x => x.PolicyHolderEmail).Description("Email of the policy holder").Name("policyHolderEmail");
            Field(x => x.PolicyHolderPhone).Description("Phone number of the policy holder").Name("policyHolderPhone");
            Field(x => x.PolicyHolderFax).Description("Fax number of the policy holder").Name("policyHolderFax");
            Field(x => x.PolicyHolderStateOrProvince).Description("State or province of the policy holder").Name("policyHolderStateOrProvince");
            Field(x => x.PolicyHolderZip).Description("Zip code of the policy holder").Name("policyHolderZip");
        }
    }
}