using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomerRestAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder();
            if (environment.IsDevelopment())
                builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();

            CustomerAppContext.ConnectionString = environment.IsDevelopment() ? Configuration["secretConnectionString"] : Environment.GetEnvironmentVariable("SQLAZURECONNSTR_DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //CustomerAppContext.ConnectionString = Configuration["secretConnectionString"];
            services.AddCors();
            services.AddMvc();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            //HTTPS
            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new RequireHttpsAttribute());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //var facade = new BLLFacade();
                //var adress = facade.AdressService.Create(
                //    new AdressBO()
                //    {
                //        City = "Kolding",
                //        Street = "SesamStrasse",
                //        Number = "22A"
                //    });
                //var adress2 = facade.AdressService.Create(
                //    new AdressBO()
                //    {
                //        City = "BingoCity",
                //        Street = "DingoDoink",
                //        Number = "2e2"
                //    });
                //var adress3 = facade.AdressService.Create(
                //    new AdressBO()
                //    {
                //        City = "Hurly Smurf",
                //        Street = "Trainstiik",
                //        Number = "44d"
                //    });
                //var customer = facade.CustomerService.Create(
                //    new CustomerBO()
                //    {
                //        FirstName = "Lars",
                //        LastName = "Bilde",
                //        AddressesIds = new List<int>() { adress.Id, adress3.Id }
                //    });
                //facade.CustomerService.Create(
                //    new CustomerBO()
                //    {
                //        FirstName = "Ole",
                //        LastName = "Eriksen",
                //        AddressesIds = new List<int>() { adress.Id, adress2.Id }
                //    });
                //for (int i = 0; i < 5; i++)
                //{
                //    facade.OrderService.Create(
                //        new OrderBO()
                //        {
                //            DeliveryDate = DateTime.Now.AddMonths(1),
                //            OrderDate = DateTime.Now.AddMonths(-1),
                //            CustomerId = customer.Id
                //        });
                //}
            }

            //CORS

            //app.UseCors
            //(
            //    builder => builder
            //    .WithOrigins("http://www.test-cors.org", "")
            //    .AllowAnyMethod()
            //    .AllowCredentials()
            //);
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowCredentials());
            app.UseMvc();
        }
    }
}
