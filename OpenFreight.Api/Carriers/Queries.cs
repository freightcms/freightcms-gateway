using GraphQL.Execution;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers.Data.Context;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Api.Carriers;

public class CarrierType : ObjectGraphType<CarrierModel>
{
    public CarrierType()
    {
        Field(x => x.ID, type: typeof(IdGraphType)).Description("ID of the Carrier").Name("id");
        Field(x => x.Name).Description("Name of the Carrier").Name("carrierName");
        Field(x => x.IsActive).Description("Flag for inidicating if the carrier is active").Name("isActive").DefaultValue(false);
        Field(x => x.Insurance, type: typeof(ListGraphType<CarrierInsuranceType>)).Description("Insurance information for the carrier").Name("insurance");
        Field(x => x.Contacts, type: typeof(ListGraphType<CarrierContactType>)).Description("Contact information for the carrier").Name("contacts");
        Field(x => x.IdentifyingCodes, type: typeof(ListGraphType<CarrierIdentifyingCodeType>)).Description("Identifying codes for the carrier").Name("identifyingCodes");
    }
}

public class CarrierInsuranceType : ObjectGraphType<CarrierInsuranceModel>
{
    public CarrierInsuranceType()
    {
        Field(x => x.ID, type: typeof(IdGraphType)).Description("ID of the Insurance").Name("id");
        Field(x => x.PolicyNumber).Description("Policy number").Name("policyNumber");
        Field(x => x.PolicyExpiration).Description("Expiration date for the policy").Name("policyExpiration");
        Field(x => x.InsuranceAmount).Description("Amount of insurance").Name("insuranceAmount");
        Field(x => x.InsuranceDeductible).Description("Deductible for the insurance").Name("insuranceDeductible");
        Field(x => x.InsuranceType).Description("Type of insurance").Name("insuranceType");
        Field(x => x.InsuranceNotes, nullable: true).Description("Notes for the insurance").Name("insuranceNotes");
        // policy holder information
        Field(x => x.PolicyHolderAddress1).Description("Address line 1 for the policy holder").Name("policyHolderAddress1");
        Field(x => x.PolicyHolderAddress2, nullable: true).Description("Address line 2 for the policy holder").Name("policyHolderAddress2");
        Field(x => x.PolicyHolderAddress3, nullable: true).Description("Address line 3 for the policy holder").Name("policyHolderAddress3");
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

public class CarrierContactType : ObjectGraphType<CarrierContactModel>
{
    public CarrierContactType()
    {
        Field(x => x.ID, type: typeof(IdGraphType)).Description("ID of the Contact").Name("id");
        Field(x => x.Email).Description("Email address of the contact").Name("email");
        Field(x => x.Phone).Description("Phone number of the contact").Name("phone");
        Field(x => x.Fax, nullable: true).Description("Fax number of the contact").Name("fax");
        Field(x => x.Mobile, nullable: true).Description("Mobile number of the contact").Name("mobile");
        Field(x => x.FullName).Description("Name of the contact").Name("fullName");
        Field(x => x.Notes, nullable: true).Description("Notes for the contact").Name("notes");
    }
}

public class CarrierIdentifyingCodeType : ObjectGraphType<CarrierIdentifyingCode>
{
    public CarrierIdentifyingCodeType()
    {
        Field(x => x.ID, type: typeof(IdGraphType)).Description("ID of the Identifying Code").Name("id");
        Field(x => x.Code).Description("Code for the Identifying Code").Name("code");
        Field(x => x.CodeType).Description("Type of the Identifying Code").Name("codeType");
    }
}

public class CarrierQuery : ObjectGraphType
{
    public CarrierQuery()
    {
        Field<ListGraphType<CarrierType>>("carriers")
            .Argument<IdGraphType>("id", nullable: true)
            .Argument<StringGraphType>("name", nullable: true)
            .ResolveAsync(async context =>
            {
                if (context.RequestServices is null)
                {
                    throw new ArgumentNullException(nameof(context.RequestServices));
                }

                context.Arguments.TryGetValue("id", out ArgumentValue idArgument);
                context.Arguments.TryGetValue("name", out ArgumentValue nameArgument);

                var carrierDbContext = context.RequestServices.GetRequiredService<CarrierDbContext>();
                IQueryable<CarrierModel> carriers = carrierDbContext.Carriers;
                if (idArgument.Value != null && Guid.TryParse(idArgument.Value.ToString(), out Guid id))
                {
                    carriers = carriers.Where(x => x.ID == id);
                }
                if (nameArgument.Value != null)
                {
                    carriers = carriers.Where(x => x.Name.Contains((string)nameArgument.Value));
                }

                var results = await carriers.ToListAsync();

                return results;
            });
    }
}