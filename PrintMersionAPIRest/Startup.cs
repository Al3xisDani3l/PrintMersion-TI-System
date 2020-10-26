using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;
using PrintMersion.Infrastructure.Data;
using PrintMersion.Infrastructure.Filters;
using PrintMersion.Infrastructure.Repositories;
using PrintMersion.Infrastructure.Services;
using System;
using System.IO;
using System.Reflection;

namespace PrintMersionAPIRest
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




            services.AddControllers(option => option.Filters.Add<GlobalExceptionFilter>()).AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //configuramos la injeccion encargada de mappear entidades.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Agregamos y configuramos la base de datos.
            services.AddDbContext<PrintMersionDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PrintMersionDB")));


            #region Entidades de dominio

            services.AddTransient<IRepository<Address>, RepositoryBase<Address, PrintMersionDBContext>>();
            services.AddTransient<IRepository<Administer>, RepositoryBase<Administer, PrintMersionDBContext>>();
            services.AddTransient<IRepository<Catalog>, RepositoryBase<Catalog, PrintMersionDBContext>>();
            services.AddTransient<IRepository<Customer>, RepositoryBase<Customer, PrintMersionDBContext>>();
            services.AddTransient<IRepository<Order>, RepositoryBase<Order, PrintMersionDBContext>>();
            services.AddTransient<IRepository<Picture>, RepositoryBase<Picture, PrintMersionDBContext>>();
            services.AddTransient<IRepository<Product>, RepositoryBase<Product, PrintMersionDBContext>>();
            services.AddTransient<IRepository<Tool>, RepositoryBase<Tool, PrintMersionDBContext>>();

            #endregion



            services.AddTransient<IService<Address>, BaseService<Address>>();
            services.AddTransient<IService<Administer>, BaseService<Administer>>();
            services.AddTransient<IService<Catalog>, BaseService<Catalog>>();
            services.AddTransient<IService<Customer>, BaseService<Customer>>();
            services.AddTransient<IService<Order>, BaseService<Order>>();
            services.AddTransient<IService<Picture>, BaseService<Picture>>();
            services.AddTransient<IService<Product>, BaseService<Product>>();
            services.AddTransient<IService<Tool>, BaseService<Tool>>();
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "PrintMersion API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlPath);
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PrintMersion API Documentation");
              
                
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
