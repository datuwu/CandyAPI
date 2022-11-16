using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SweetIncApi.BusinessModels;
using SweetIncApi.Helper;
using SweetIncApi.Models;
using SweetIncApi.Repository;
using SweetIncApi.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SweetIncApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", true)
                          .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SweetIncApi", Version = "v1" });
            });
            //var connectionString = $"Server=sweetincapidbserver.database.windows.net,1433;User Id=buigiaan@sweetincapidbserver;" +                $"Password=An29122001;Database=SweetIncApi_db;";
            var connectionString = "Server=(local);Database=CandyStore;Trusted_Connection=True;";
            services.AddDbContext<CandyStoreContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            #region Add repo services
            services.AddScoped<IBoxRepository, BoxRepository>();
            services.AddScoped<IBoxProductRepository, BoxProductRepository>();
            services.AddScoped<IBoxPatternRepository, BoxPatternRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICatagoryRepository, CatagoryRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOriginRepository, OriginRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            //services.AddControllers().AddJsonOptions(c => c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SweetIncApi v1"));
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SweetIncApi v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x

                                            .AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
