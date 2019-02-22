using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using NajmetAlraqeeSite.Data;
using NajmetAlraqeeSite.Models;
using NajmetAlraqeeSite.Services;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using AutoMapper;
using NajmetAlraqeeSite.AutoMapper;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using NajmetAlraqeeSite.Resources;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
//using NToastNotify;

namespace NajmetAlraqeeSite
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddDbContext<NajmetAlraqeeContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                //options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<NajmetAlraqeeContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IHospitalRepository, HospitalRepository>();
            services.AddTransient<IHospitalOfferRepository, HospitalOfferRepository>();
            services.AddTransient<IDoctorLanguageRepository, DoctorLanguageRepository>();
            services.AddTransient<IDoctorEducationLevelRepository, DoctorEducationLevelRepository>();
            services.AddTransient<IDoctorSpecialtyRepository, DoctorSpecialtyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDoctorVacationRepository, DoctorVacationRepository>();
            services.AddTransient<IPatientAppointmentRepository, PatientAppointmentRepository>();

            services.AddTransient<INationalityRepository, NationalityRepository>();
            services.AddTransient<IBankDetailRepository, BankDetailRepository>();
            services.AddTransient<IJobTypeReository, JobTypeReository>();
            services.AddTransient<IDelegateReository, DelegateReository>();
            services.AddTransient<IDelegateTypeRepository, DelegateTypeRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<ICurrencyTypeRepository, CurrencyTypeRepository>();
            services.AddTransient<IArrivalRepository, ArrivalRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IForeignAgencyRepository, ForeignAgencyRepository>();
            //// configure identity server with in-memory stores, keys, clients and scopes
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryPersistedGrants()
            //    .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //    .AddInMemoryApiResources(Config.GetApiResources())
            //    .AddInMemoryClients(Config.GetClients())
            //   .AddAspNetIdentity<User>();

            services.AddAutoMapper();

            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopLeft
            });

            services.AddSingleton<LocService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("SharedResource", assemblyName.Name);
                    };
                });

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                        {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar")
                        };

                    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;

                    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); ;
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            app.UseStaticFiles();

            //app.UseIdentity();
            app.UseAuthentication();
            app.UseNToastNotify();
            ////   app.UseAuthentication(); // not needed, since UseIdentityServer adds the authentication middleware
            //app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
