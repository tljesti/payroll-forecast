using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using PayrollForecast.Api.BusinessLogic;
using PayrollForecast.Api.Services;

namespace PayrollForecast.Api
{
    public class Startup
    {
        private const string _corsPolicy = "AllowAllOriginsHeadersAndMethods";
        private const string _connString = "database";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options  =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicy,
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString(_connString)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmployeeBusinessLogic, EmployeeBusinessLogic>();
            services.AddTransient<IPaymentBusinessLogic, PaymentBusinessLogic>();
            services.AddTransient<IDeductionBusinessLogic, DeductionBusinessLogic>();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_corsPolicy);

            app.UseMvc();
        }
    }
}
