using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using ODataApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EFModel.FirmaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Firma")));

builder.Services
       .AddControllers()
       .AddOData(opt => opt.AddRouteComponents("odata", FirmaODataModelBuilder.GetEdmModel()));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
