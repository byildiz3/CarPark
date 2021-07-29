using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CarPark.Business.Abstract;
using CarPark.Business.Concrete;
using CarPark.Core.Repository.Abstract;
using CarPark.Core.Settings;
using CarPark.DataAccess.Abstract;
using CarPark.DataAccess.Concrete;
using CarPark.DataAccess.Repository;
using CarPark.User.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CarPark.User
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
            services.AddControllersWithViews();
            services.AddLocalization(x => { x.ResourcesPath = "Resources"; });
            services.AddMvc()
                .AddViewLocalization()

                .AddDataAnnotationsLocalization(
                    
                    options=> options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName =
                            new AssemblyName(typeof(SharedModelResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create(nameof(SharedModelResource), assemblyName.Name);
                    }
                    );

            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });

            ///DI Start
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepositoryBase<>));
            services.AddScoped<IPersonelDataAccess, PersonelDataAccess>();
            services.AddScoped<IPersonelService, PersonelService>();


            ///////



            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCulture = new List<CultureInfo>()
                {
                    new CultureInfo("en-Us"),
                    new CultureInfo("tr-TR"),
                    new CultureInfo("ar-SA"),

                };
                opt.DefaultRequestCulture = new RequestCulture("tr-TR");
                opt.SupportedCultures = supportedCulture;
                opt.SupportedUICultures = supportedCulture;

                opt.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
                opt.RequestCultureProviders = new[]
                {
                    new RouteDataRequestCultureProvider()
                    {
                        Options = opt,
                    }
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            var opt = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(opt.Value);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{culture=tr-TR}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
