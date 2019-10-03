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
using Rotativa.AspNetCore;
using NajmetAlraqee.Site;

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
            //services.AddDevExpressControls(); // DevExpress Report
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<NajmetAlraqeeContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<NajmetAlraqeeContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
         
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
         
            services.AddTransient<IUserRepository, UserRepository>();
           
         

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
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerTypeRepository,CustomerTypeRepository>();
            services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddTransient<IPartnerRepository, PartnerRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IReligionRepository, ReligionRepository>();
            services.AddTransient<ISocialStatusRepository, SocialStatusRepository>();
            services.AddTransient<IContractRepository, ContractRepository>();
            services.AddTransient<IContractTypeRepository, ContractTypeRepository>();
            services.AddTransient<IContractSelectRepository, ContractSelectRepository>();
            services.AddTransient<IContractDelegateRepository, ContractDelegateRepository>();
            services.AddTransient<IContractVisaRepository, ContractVisaRepository>();
            services.AddTransient<IContractTicketRepository, ContractTicketRepository>();
            services.AddTransient<IContractHistoryRepository, ContractHistoryRepository>();
            services.AddTransient<IReceiptDocRepository, ReceiptDocRepository>();
            services.AddTransient<IReceiptDocTypeRepository, ReceiptDocTypeRepository>();
            services.AddTransient<ISpecialEmployeeRepository, SpecialEmployeeRepository>();
            services.AddTransient<ISpecificContractRepository, SpecificContractRepository>();
            services.AddTransient<IContractReturnRepository, ContractReturnRepository>();
            services.AddTransient<IReturnReasonRepository, ReturnReasonRepository>();

            services.AddTransient<ISnadReceiptTypeRepository, SnadReceiptTypeRepository>();
            services.AddTransient<ISnadReceiptCaluseRepository, SnadReceiptCaluseRepository>();
            services.AddTransient<ISnadReceiptRepository, SnadReceiptRepository>();

            services.AddTransient<ITransferPurposeRepository, TransferPurposeRepository>();
            services.AddTransient<IForeignAgencyTransferRepository, ForeignAgencyTransferRepository>();
            services.AddTransient<IDelegateTransferRepository, DelegateTransferRepository>();
            services.AddTransient<IForeignAgencyJobRepository, ForeignAgencyJobRepository>();


            services.AddTransient<IAccountClassificationRepository, AccountClassificationRepository>();
            services.AddTransient<IAccountClassificationTypeRepository, AccountClassificationTypeRepository>();
            services.AddTransient<IFinancialPeriodRepository, FinancialPeriodRepository>();
            services.AddTransient<IFinancialPeriodStatusRepository, FinancialPeriodStatusRepository>();
            services.AddTransient<IAccountTreeRepository, AccountTreeRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IRecruitmentQaidRepository, RecruitmentQaidRepository>();
            services.AddTransient<IRecruitmentQaidTypeRepository, RecruitmentQaidTypeRepository>();
            services.AddTransient<IRecruitmentQaidStatusRepository, RecruitmentQaidStatusRepository>();
            services.AddTransient<IRecruitmentQaidDetailRepository, RecruitmentQaidDetailRepository>();
            services.AddTransient<IRecruitmentQaidDetailTypeRepository, RecruitmentQaidDetailTypeRepository>();

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
            //services.AddDevExpressControls();
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
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
            }
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
            //    RequestPath = "/node_modules"
            //});
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            app.UseFastReport();
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
            // var webRootPath = env.WebRootPath;
            // call rotativa conf passing env to get web root path
            RotativaConfiguration.Setup(env);
        }
    }
}
