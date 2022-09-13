using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using ProductCatalogManagerAPI.Application.Mappers;
using ProductCatalogManagerAPI.Application.Validators;
using ProductCatalogManagerAPI.Infrastructure.Filters;
using ProductCatalogManagerAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceServices();
builder.Services.AddFluentValidationAutoValidation(opt => opt.DisableDataAnnotationsValidation = true);
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product Catalog manager API", Version = "v1" });
    var XMLFiles = Directory.GetFiles(PlatformServices.Default.Application.ApplicationBasePath, "*.xml");
    foreach (var item in XMLFiles)
    {
        c.IncludeXmlComments(item);
    }
}
    );
builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
            c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "ProductCatalogManagerAPI v1");
        });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();