using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;

namespace CommanderGQL
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("ConnectionCommon")));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
                 
            }, "/graphql-voyager");
           
        }
    }
}
