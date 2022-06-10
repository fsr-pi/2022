using EFModel;
using GraphQL.Server.Ui.Voyager;
using GraphQLServer.SetupGraphQL;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FirmaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Firma")));


builder.Services.AddGraphQLServer()
        .SetPagingOptions(new PagingOptions
        {
          DefaultPageSize = 20,
          MaxPageSize = 1000,
          IncludeTotalCount = true
        })
        .AddProjections()
        .AddFiltering()
        .AddSorting()
        .AddQueryType<Queries>()
        .AddMutationType<Mutations>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.MapGraphQL();

app.UseGraphQLVoyager(new VoyagerOptions()
                          {
                            GraphQLEndPoint = "/graphql"
                          },
                          "/graphql-voyager");

app.Run();