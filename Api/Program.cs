using Application;
using Application.Services;
using Domain;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// Add configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Get the CSV file path from configuration
string csvFilePath = builder.Configuration.GetValue<string>("CsvFilePath");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IDeviceRepository>(provider => new DeviceRepository(csvFilePath));
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .Build();
    });
});
var app = builder.Build();
app.UseCors("default");
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
