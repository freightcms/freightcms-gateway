using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using OpenFreight.Carriers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    builder.Services.AddDbContext<CarrierDbContext>((options) => 
        options.UseInMemoryDatabase("Carriers"), ServiceLifetime.Transient);
}
else 
{
    builder.Services.AddDbContext<CarrierDbContext>((options) => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("Carriers")), ServiceLifetime.Transient);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
