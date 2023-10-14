using Microsoft.EntityFrameworkCore;
using OpenFreight.Carriers;
using EntityGraphQL.AspNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CarrierDbContext>((options) => 
    options.UseInMemoryDatabase("Carriers"), ServiceLifetime.Transient);

// This registers a SchemaProvider<DemoContext> and uses reflection to build the schema with default options
builder.Services.AddGraphQLSchema<CarrierDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.MapGraphQL<CarrierDbContext>("/graphql");

// app.UseAuthorization();
app.Run();
