using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MutantDetector.Application;
using MutantDetector.Application.Abstractions;
using MutantDetector.Domain;
using MutantDetector.Domain.Abstractions;
using MutantDetector.Domain.Entities.Builders;
using MutantDetector.Domain.Evaluators;
using MutantDetector.Domain.Evaluators.RangeEvaluators;
using MutantDetector.Infrastructure;
using MutantDetector.Infrastructure.Abstractions;

namespace MutantDetector.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            InjectDependencies(services);

            var connString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            var databaseName = Configuration.GetSection("MongoConnection:Database").Value;

            services.AddHealthChecks()
                .AddMongoDb(MongoClientSettings.FromConnectionString(connString), name: "MongoDb");

            services.Configure<DbSettings>(options =>
            {
                options.ConnectionString =connString;
                options.Database = databaseName;
            });
        }

        private static void InjectDependencies(IServiceCollection services)
        {
            services.AddTransient<IHumanDnaBuilder, HumanDnaBuilder>();
            services.AddTransient<IDnaEvaluator, DnaEvaluator>();
            services.AddTransient<IMutantConfiguration, MutantConfiguration>();

            services.AddTransient<IRangeEvaluator, ColumnEvaluator>();
            services.AddTransient<IRangeEvaluator, RowEvaluator>();
            services.AddTransient<IRangeEvaluator, MainDiagonalEvaluator>();
            services.AddTransient<IRangeEvaluator, AntiDiagonalEvaluator>();

            services.AddTransient<IDnaEvaluatorService, DnaEvaluatorService>();
            services.AddTransient<IHumanDnaReposity, HumanDnaReposity>();
            services.AddTransient<IMutantDetectorDbContext, MutantDetectorDbContext>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }            

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseHealthChecks("/healthcheck");
        }
    }
}
