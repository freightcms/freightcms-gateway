using Microsoft.EntityFrameworkCore;
using GraphQL;
using OpenFreight.Api.Carriers;
using OpenFreight.Carriers.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CarrierDbContext>((options) => 
    options.UseInMemoryDatabase("Carriers"), ServiceLifetime.Transient);
builder.Services.AddScoped<CarrierQuery>();
builder.Services.AddScoped<CarrierType>();
builder.Services.AddScoped<CarrierMutation>();
builder.Services.AddScoped<CreateCarrerInputType>();
builder.Services.AddGraphQL(configure => 
{
    configure.AddSchema<CarrierSchema>(GraphQL.DI.ServiceLifetime.Scoped).AddSystemTextJson();
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseGraphQL("/graphql");            // url to host GraphQL endpoint
app.UseGraphQLPlayground(
    "/",                               // url to host Playground at
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });

// app.UseAuthorization();
app.Run();
