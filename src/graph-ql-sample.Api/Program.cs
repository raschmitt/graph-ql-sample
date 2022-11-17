using graph_ql_sample.GraphQL.Mutations;
using graph_ql_sample.GraphQL.Queries;
using graph_ql_sample.Register;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddRedis(configuration);
services.AddHealthChecks(configuration);

services
    .AddGraphQLServer()
    .AddQueryType<BookQuery>()
    .AddMutationType<BookMutation>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{ 
    endpoints.MapHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});
app.UseHttpsRedirection();
app.MapGraphQL();
app.Run();
