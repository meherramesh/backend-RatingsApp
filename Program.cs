using DinkToPdf;
using DinkToPdf.Contracts;
using System.Reflection;
using System.Runtime.Loader;


using Microsoft.EntityFrameworkCore;
using RatingsApp.Data;
using RatingsApp.Repositories.Interfaces;
using RatingsApp.Repositories.Implementations;
using RatingsApp.Services.Interfaces;
using RatingsApp.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

/// --------------------
/// ADD SERVICES
/// --------------------

// Controllers + JSON options


var context = new CustomAssemblyLoadContext();
var path = Path.Combine(Directory.GetCurrentDirectory(), "DinkToPdf", "libwkhtmltox.dll");
context.LoadUnmanagedLibrary(path);





builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

/// --------------------
/// REPOSITORIES
/// --------------------
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IQualityRepository, QualityRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<ICostRepository, CostRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IResponseRepository, ResponseRepository>();
builder.Services.AddScoped<IOverallRepository, OverallRepository>();

/// --------------------
/// SERVICES
/// --------------------
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IQualityService, QualityService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<ICostService, CostService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<IOverallService, OverallService>();


builder.Services.AddSingleton(typeof(IConverter),
    new SynchronizedConverter(new PdfTools()));


var app = builder.Build();

/// --------------------
/// MIDDLEWARE
/// --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseAuthorization();
app.MapControllers();

app.Run();

public class CustomAssemblyLoadContext : AssemblyLoadContext
{
    public IntPtr LoadUnmanagedLibrary(string absolutePath)
    {
        return LoadUnmanagedDllFromPath(absolutePath);
    }

    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
    {
        return LoadUnmanagedDllFromPath(unmanagedDllName);
    }

    protected override Assembly Load(AssemblyName assemblyName)
    {
        return null;
    }
}

