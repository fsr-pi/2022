using EFModel;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApi;
using WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// add/configure services
builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>())
                .AddJsonOptions(configure => configure.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<FirmaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Firma")));
builder.Services.AddTransient<MjestoController>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc(Constants.ApiVersion, new OpenApiInfo
  {
    Title = "Firma Web API",
    Version = Constants.ApiVersion
  });
  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  c.IncludeXmlComments(xmlPath);

  //e.g. include comment from EFModel (not needed, bust just for demonstration)
  xmlFile = $"{typeof(EFModel.Artikl).Assembly.GetName().Name}.xml";
  xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0#middleware-order-1

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.RoutePrefix = "docs";
  c.DocumentTitle = "Firma Web Api";
  c.SwaggerEndpoint($"../swagger/{Constants.ApiVersion}/swagger.json", "Firma WebAPI");
});


app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();