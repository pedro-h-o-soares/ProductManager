using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProductManager.Application.Interfaces;
using ProductManager.Application.Service;
using ProductManager.Domain.Core.Interfaces.Repositories;
using ProductManager.Domain.Core.Services;
using ProductManager.Domain.Services.Services;
using ProductManager.Infraestructure.Data;
using ProductManager.Infraestructure.Repository.Repositories;
using ProductManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using ProductManager.Infrastruture.CrossCutting.Adapter.Map;

namespace ProductManager.Presentation
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

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connectionString));
            services.AddMemoryCache();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductManager.Presentation", Version = "v1" });
            });

            services.AddScoped<IApplicationServiceProduct, ApplicationServiceProduct>();
            services.AddScoped<IServiceProduct, ServiceProduct>();
            services.AddScoped<IRepositoryProduct, RepositoryProduct>();
            services.AddScoped<IMapperProduct, MapperProduct>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductManager.Presentation v1"));
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
