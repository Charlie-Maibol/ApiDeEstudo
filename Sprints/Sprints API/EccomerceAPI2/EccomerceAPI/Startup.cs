
using Eccomerce.Test;
using EccomerceAPI.Data;
using EccomerceAPI.Data.Dao;
using EccomerceAPI.Data.productDao;
using EccomerceAPI.Interface;
using EccomerceAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;


namespace EccomerceAPI
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
            services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseMySQL(Configuration.GetConnectionString("CategoryConnection")));
            services.AddScoped<CategoryServices, CategoryServices>();
            services.AddScoped<ICategoryDao, CategoryDao>();
            services.AddScoped<SubCategoryServices, SubCategoryServices>();
            services.AddScoped<ISubCategoryDao, SubCategoryDao>();
            services.AddScoped<ProductsServices, ProductsServices>();
            services.AddScoped<IProductDao, ProductDao>();
            services.AddScoped<DistributionCenterServices, DistributionCenterServices>();
            services.AddScoped<DistributionCenterDao>();
            services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EccomerceAPI", Version = "v1" });
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EccomerceAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
