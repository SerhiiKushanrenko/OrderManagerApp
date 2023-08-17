using API.GraphQL;
using Core.Interfacies;
using GraphQL.Server.Ui.Voyager;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var AllowSpecificOrigins = "_allowSpecificOrigins"; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextFactory<OMAContext>(
    options => {
        options.UseInMemoryDatabase("InMemoryDb");
    }
);

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services
.AddGraphQLServer()
.AddQueryType<Query>()
.AddFiltering();

builder.Services.AddCors(options => 
{
    options.AddPolicy(name: AllowSpecificOrigins,
        policy => 
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors(AllowSpecificOrigins);

app.MapGraphQL();

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions  {GraphQLEndPoint  = "/graphql"});

app.Run();
