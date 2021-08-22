using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MiniAzureDevops.ItemTable.Api.Middlewares;
using MiniAzureDevops.ItemTable.Application;
using MiniAzureDevops.ItemTable.Application.Mapping;
using MiniAzureDevops.ItemTable.Persistance;
using System.Reflection;

namespace MiniAzureDevops.ItemTable.Api
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
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            AutoMapperConfig.RegisterMappings(typeof(IMapFrom<>).GetTypeInfo().Assembly);

            services.AddApplicationServices();
            services.AddSQLPersistanceServices(this.Configuration);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MiniAzureDevops.ItemTable.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MiniAzureDbContext context)
        {
            if (env.IsDevelopment())
            {
                context.Database.Migrate();   
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniAzureDevops.ItemTable.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAllOrigins");

            app.UseCustomExceptionHandler();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
