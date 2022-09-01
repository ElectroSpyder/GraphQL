using GrapfQL.Core.Api;
using GrapfQL.Core.Models;
using GrapfQL.Core.Resolvers;
using GrapfQL.Core.Resolvers.Mutations;
using GrapfQL.Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FootballDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPositionService, PositionService>();

//Exponer los objetos player, position, etc.
//builder.Services.AddGraphQLServer().AddQueryType<Query>();
builder.Services.AddGraphQLServer()
    .AddQueryType(x => x.Name("Query"))
    .AddType<PlayerQueryResolver>()
    .AddType<PositionQueryResolver>()
    .AddMutationType(m => m.Name("Mutation"))
    .AddType<PlayerMutationResolver>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

//make /graphql per default like endpoint  "/my/graphql/endpoint"
app.MapGraphQL();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
