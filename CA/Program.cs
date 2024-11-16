using CA.Infrastructure.Data;
using CA.Infrastructure.Repositories;
using CA.Domain.Interfaces.Vendedores;
using CA.Application.Interfaces;
using CA.Application.Services;
using CA.Domain.Interfaces.Registros;
using CA.Application.Services.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IVendedorData, VendedorData>();
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();
builder.Services.AddScoped<IVendedorService, VendedorService>();

builder.Services.AddScoped<IRegistroData, RegistroData>();
builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();

builder.Services.AddScoped<IVendedorPorVentasService<VendedorPorVentasEntity>, VendedorPorVentasService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture Demo");
//        c.RoutePrefix = string.Empty; // Set Swagger UI at app's root
//    });
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
