using WebCoreApi.DAORespositories;
using WebCoreApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("GlobalWebPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });

                //options.AddPolicy("GlobalWebPolicy",
                //builder =>
                //{
                //    builder.WithOrigins("http://localhost:16948",
                //                        "http://localhost:16948",
                //                        "http://localhost")
                //                        .AllowAnyHeader()
                //                        .AllowAnyMethod();
                //});
            });
            services.AddTransient<IGlobalParametersRepository, GlobalParametersRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IInstitutionRepository, InstitutionRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IPostalCodesRepository, PostalCodesRepository>();
            services.AddTransient<IAreaOfPostalRepository, AreaOfPostalRepository>();
            services.AddTransient<IProductMasterRepository, ProductMasterRepository>();
            services.AddTransient<IProductRateRepository, ProductRateRepository>();
            services.AddTransient<ICustomerFileUploadingRepository, CustomerFileUploadingRepository>();
            services.AddTransient<IFileUploadRepoistory, FileUploadRepoistory>();
            services.AddTransient<IQuotationRepository, QuotationRepository>();
            services.AddTransient<IQuotCompyGrpDetlRepository, QuotCompyGrpDetlRepository>();
            services.AddTransient<IQuotAgentDetlRepository, QuotAgentDetlRepository>();
            services.AddTransient<IQuotaProcessRepository, QuotaProcessRepository>();
            services.AddTransient<IReceiptingRepository, ReceiptingRepository>();
            services.AddTransient<IUnderWrittingRepository, UnderWrittingRepository>();
            services.AddTransient<IGLIndividualAdditionRepository, GLIndividualAdditionRepository>();
            services.AddTransient<IAgentRegisterRepository, AgentRegisterRepository>();
            services.AddTransient<IInquiryRepository, InquiryRepository>();
            services.AddTransient<IGrowthRateRepository, GrowthRateRepository>();


            services.AddSingleton<IConfiguration>(Configuration);
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebCoreApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            /*app.UseCors(options =>
                    options.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader());

            app.UseCors(options =>
                    options.WithOrigins("http://localhost:16948")
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebCoreApi v1"));
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
