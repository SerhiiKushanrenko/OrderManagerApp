using API.GraphQL;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextFactory<OMAContext>(
    options => {
        options.UseInMemoryDatabase("InMemoryDb");
    }
);

builder.Services
.AddGraphQLServer()
.AddQueryType<Query>()
.AddFiltering();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGraphQL();

app.Run();
