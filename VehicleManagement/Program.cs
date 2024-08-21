using Microsoft.EntityFrameworkCore;
using VehicleManagement.Data;
using VehicleManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();


builder.Services.AddAuthentication(
    
    
    );

builder.Services.AddDbContext<VehicleDbContext>(options =>
{
    var connstring = builder.Configuration.GetConnectionString("connStr");
    options.UseSqlServer(connstring);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
