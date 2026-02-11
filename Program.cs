<<<<<<< HEAD
﻿var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// ⭐ THIS LINE WAS MISSING
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
=======
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

// 1. Controllers + JSON options (prevents circular reference issue)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// 2. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. DbContext (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 4. CORS (for Angular frontend)
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
/// REPOSITORY REGISTRATION
/// --------------------
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IQualityRepository, QualityRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<ICostRepository, CostRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IResponseRepository, ResponseRepository>();
builder.Services.AddScoped<IOverallRepository, OverallRepository>();

/// --------------------
/// SERVICE REGISTRATION
/// --------------------
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IQualityService, QualityService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<ICostService, CostService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<IOverallService, OverallService>();

var app = builder.Build();

/// --------------------
/// MIDDLEWARE PIPELINE
/// --------------------

// 1. Swagger (only in Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 2. HTTPS
app.UseHttpsRedirection();

// 3. CORS (MUST be before Authorization)
app.UseCors("AllowAngularApp");

// 4. Authorization
app.UseAuthorization();

// 5. Map Controllers
app.MapControllers();

app.Run();







//using Microsoft.EntityFrameworkCore;
//using RatingsApp.Data;
//using RatingsApp.Repositories.Implementations;
//using RatingsApp.Repositories.Interfaces;
//using RatingsApp.Services.Implementations;
//using RatingsApp.Services.Interfaces;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
//);

//builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
//builder.Services.AddScoped<ISupplierService, SupplierService>();

//builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

//var app = builder.Build();

////app.UseSwagger();
////app.UseSwaggerUI();

//app.UseHttpsRedirection();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
>>>>>>> cf24106ea1da310e2aefb36fb90a73615a80587b
