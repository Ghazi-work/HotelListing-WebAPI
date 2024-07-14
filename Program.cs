using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;


Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
    path: "D:\\Practice\\hotellistings\\logs\\log-.txt",
    outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:1j}{Newline}{Exception}{Newline}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: LogEventLevel.Information
    ).CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Connection with SQL server

builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")

    ));

// Add Serilog to the builder

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();

// Add Cors (Cross Origin Resource Sharing)

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application is starting");
    app.Run();


}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start");

}
finally
{
    Log.CloseAndFlush();
}