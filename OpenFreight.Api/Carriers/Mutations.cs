using GraphQL;
using GraphQL.Types;
using OpenFreight.Carriers.Data.Context;
using OpenFreight.Carriers.Models;

namespace OpenFreight.Api.Carriers
{
    public class CarrierInputType : InputObjectGraphType<CarrierModel>
    {
        public CarrierInputType()
        {
            Name = "CreateCarrierInput";
            Field(x => x.Name).Description("Name of the Carrier").Name("carrierName");
            Field(x => x.Insurance, type: typeof(ListGraphType<CarrierInsuranceInputType>)).Description("Insurance information for the carrier").Name("insurance");
            Field(x => x.Contacts, type: typeof(ListGraphType<CarrierContactInputType>)).Description("Contact information for the carrier").Name("contacts");
            Field(x => x.IdentifyingCodes, type: typeof(ListGraphType<CarrierIdentifyingCodeInputType>)).Description("Identifying codes for the carrier").Name("identifyingCodes");
        }
    }

    public class CarrierInsuranceInputType : InputObjectGraphType<CarrierInsuranceModel>
    {
        public CarrierInsuranceInputType()
        {
            Name = "CarrierInsuranceInput";
            Field(x => x.PolicyNumber).Description("Policy number").Name("policyNumber");
            Field(x => x.PolicyExpiration).Description("Expiration date for the policy").Name("policyExpiration");
            Field(x => x.InsuranceAmount).Description("Amount of insurance").Name("insuranceAmount");
            Field(x => x.InsuranceDeductible).Description("Deductible for the insurance").Name("insuranceDeductible");
            Field(x => x.InsuranceType).Description("Type of insurance").Name("insuranceType");
            Field(x => x.InsuranceNotes, nullable: true).Description("Notes for the insurance").Name("insuranceNotes");
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

    public class CarrierContactInputType : InputObjectGraphType<CarrierContactModel>
    {
        public CarrierContactInputType()
        {
            Name = "CarrierContactInput";
            Field(x => x.Email).Description("Email address of the contact").Name("email");
            Field(x => x.Phone).Description("Phone number of the contact").Name("phone");
            Field(x => x.Fax, nullable: true).Description("Fax number of the contact").Name("fax");
            Field(x => x.Mobile, nullable: true).Description("Mobile number of the contact").Name("mobile");
            Field(x => x.FullName).Description("Name of the contact").Name("fullName");
            Field(x => x.Notes, nullable: true).Description("Notes for the contact").Name("notes");
        }
    }

    public class CarrierIdentifyingCodeInputType : InputObjectGraphType<CarrierIdentifyingCode>
    {
        public CarrierIdentifyingCodeInputType()
        {
            Name = "CarrierIdentifyingCodeInput";
            Field(x => x.Code).Description("Code for the Identifying Code").Name("code");
            Field(x => x.CodeType).Description("Type of the Identifying Code").Name("codeType");
        }
    }

    public class CarrierContactMutation : ObjectGraphType<CarrierModel>
    {
        public CarrierContactMutation()
        {
            Field<CarrierContactType>("createCarrierContact")
                .Argument<NonNullGraphType<CarrierContactInputType>>("contact", "Contact to create")
                .Argument<NonNullGraphType<StringGraphType>>("carrierId", "Carrier ID to add the contact to")
                .Resolve(context =>
                {
                    if (context.RequestServices is null)
                    {
                        throw new ArgumentNullException(nameof(context.RequestServices));
                    }
                    var dbcontext = context.RequestServices.GetRequiredService<CarrierDbContext>();
                    var contactModel = context.GetArgument<CarrierContactModel>("contact");
                    var carrierId = context.GetArgument<Guid>("carrierId");
                    var carrier = dbcontext.Carriers.First(x => x.ID == carrierId);
                    carrier.Contacts.Add(contactModel);
                    
                    dbcontext.SaveChanges();
                    return contactModel;
                });
        }
    }

    public class CarrierIdentifyingCodeMutation : ObjectGraphType<CarrierIdentifyingCodeInputType>
    {
        public CarrierIdentifyingCodeMutation()
        {
            Field<CarrierIdentifyingCodeType>("createCarrierIdentifyingCode")
                .Argument<NonNullGraphType<CarrierIdentifyingCodeInputType>>("identifyingCode", "Identifying Code to Create")
                .Argument<NonNullGraphType<StringGraphType>>("carrierId", "Carrier ID to add the identifying code to")
                .Resolve(context =>
                {
                    if (context.RequestServices is null)
                    {
                        throw new ArgumentNullException(nameof(context.RequestServices));
                    }
                    var dbcontext = context.RequestServices.GetRequiredService<CarrierDbContext>();
                    var identifyingCodeModel = context.GetArgument<CarrierIdentifyingCode>("contact");
                    var carrierId = context.GetArgument<Guid>("carrierId");
                    var carrier = dbcontext.Carriers.First(x => x.ID == carrierId);
                    carrier.IdentifyingCodes.Add(identifyingCodeModel);
                    
                    dbcontext.SaveChanges();
                    return identifyingCodeModel;
                });
        }
    }

    public class CarrierInsuranceMutation : ObjectGraphType<CarrierInsuranceModel>
    {
        public CarrierInsuranceMutation()
        {
            Field<CarrierInsuranceType>("createCarrierInsurance")
                .Argument<NonNullGraphType<CarrierInsuranceInputType>>("insurance", "Insurance to Create")
                .Argument<NonNullGraphType<StringGraphType>>("carrierId", "Carrier ID to add the insurance to")
                .Resolve(context => 
                {
                    if (context.RequestServices is null)
                    {
                        throw new ArgumentNullException(nameof(context.RequestServices));
                    }
                    var dbcontext = context.RequestServices.GetRequiredService<CarrierDbContext>();
                    var insuranceModel = context.GetArgument<CarrierInsuranceModel>("insurance");
                    var carrierId = context.GetArgument<Guid>("carrierId");
                    var carrier = dbcontext.Carriers.First(x => x.ID == carrierId);
                    carrier.Insurance.Add(insuranceModel);
                    
                    dbcontext.SaveChanges();
                    return insuranceModel;
                });
        }
    } 

    public class CarrierMutation : ObjectGraphType
    {
        public CarrierMutation()
        {
            Field<CarrierType>("createCarrier")
                .Argument<NonNullGraphType<CarrierInputType>>("carrier", "Carrier to create")
                .ResolveAsync(async context =>
                {
                    if (context.RequestServices is null)
                    {
                        throw new ArgumentNullException(nameof(context.RequestServices));
                    }
                    var dbcontext = context.RequestServices.GetRequiredService<CarrierDbContext>();
                    var carrierModel = context.GetArgument<CarrierModel>("carrier");
                    await dbcontext.Carriers.AddAsync(carrierModel);
                    await dbcontext.SaveChangesAsync();
                    return carrierModel;
                });
        }
    }
}