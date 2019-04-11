using NajmetAlraqee.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data
{
    public class NajmetAlraqeeContext : IdentityDbContext<User>
    {
        public NajmetAlraqeeContext(DbContextOptions<NajmetAlraqeeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            var cascadeFKs = modelbuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetForeignKeys())
               .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelbuilder.Entity<CustomerType>()
                .HasData(new CustomerType
                {
                    Id = 1,
                    Name = "داخلي",
                },
                new CustomerType
                {
                    Id = 2,
                    Name = "خارجي",
                }
            );

            modelbuilder.Entity<DelegateType>()
                .HasData(new DelegateType
                {
                    Id = 1,
                    Name = "مندوب داخلي ",
                },
                new DelegateType
                {
                    Id = 2,
                    Name = "مندوب خارجي ",
                }
            );
            modelbuilder.Entity<Nationality>()
                .HasData(new Nationality
                {
                    Id = 1,
                    Name = "السعودية"
                },
                new Nationality
                {
                    Id = 2,
                    Name = "مصر",
                }
            );
            modelbuilder.Entity<CurrencyType>()
               .HasData(new CurrencyType
               {
                   Id = 1,
                   Name = "عملة محلية"
               },
               new CurrencyType
               {
                   Id = 2,
                   Name = "عملة أجنبية",
               }
           );
            modelbuilder.Entity<Gender>()
               .HasData(new Gender
               {
                   Id = 1,
                   Name = "ذكر"
               },
               new Gender
               {
                   Id = 2,
                   Name = "أنثي",
               }
           );
            modelbuilder.Entity<SocialStatus>()
              .HasData(new SocialStatus
              {
                  Id = 1,
                  Name = "عازب/ة",
              },
              new SocialStatus
              {
                  Id = 2,
                  Name = "متزوج/ة",
              }
          );
            modelbuilder.Entity<Religion>()
              .HasData(new Religion
              {
                  Id = 1,
                  Name = "مسلم",
              },
              new Religion
              {
                  Id = 2,
                  Name = "مسيحي",
              }
          );
            modelbuilder.Entity<EmployeeStatus>()
               .HasData(new EmployeeStatus
               {
                   Id = 1,
                   Name = "علي راس العمل",
               },
               new EmployeeStatus
               {
                   Id = 2,
                   Name = "تجربة",
               }, new EmployeeStatus
               {
                   Id = 3,
                   Name = "خروج نهائي",
               }, new EmployeeStatus
               {
                   Id = 4,
                   Name = "هروب",
               }, new EmployeeStatus
               {
                   Id = 5,
                   Name = "نقل كفالة",
               }, new EmployeeStatus
               {
                   Id = 6,
                   Name = "في السكن",
               }, new EmployeeStatus
               {
                   Id = 7,
                   Name = "جديد",
               }
           );

            modelbuilder.Entity<ContractStatus>()
               .HasData(new ContractStatus
               {
                   Id = 1,
                   Name = "جديد",
               },
               new ContractStatus
               {
                   Id = 2,
                   Name = "تم الاختيار",
               }, new ContractStatus
               {
                   Id = 3,
                   Name = "تم التفويض",
               }, new ContractStatus
               {
                   Id = 4,
                   Name = "تم التفيز",
               }, new ContractStatus
               {
                   Id = 5,
                   Name = "تذكرة سفر",
               }, new ContractStatus
               {
                   Id = 6,
                   Name = "استرجاع",
               }, new ContractStatus
               {
                   Id = 7,
                   Name = "انتهي",
               }
           );

            modelbuilder.Entity<ContractType>()
             .HasData(new ContractType
             {
                 Id = 1,
                 Name = "أستقدام",
             },
             //new ContractType
             //{
             //    Id = 3,
             //    Name = "أستقدام",
             //},
             new ContractType
             {
                 Id = 2,
                 Name = "بديل",
             }
         );

            modelbuilder.Entity<ContractAction>()
              .HasData(new ContractAction
              {
                  Id = 1,
                  Name = "تم انشاء العقد",
              },
              new ContractAction
              {
                  Id = 2,
                  Name = "تم الاختيار",
              }, new ContractAction
              {
                  Id = 3,
                  Name = "تم التفويض",
              }, new ContractAction
              {
                  Id = 4,
                  Name = "تم التفيز",
              }, new ContractAction
              {
                  Id = 5,
                  Name = "تم حجز تذكرة سفر",
              }, new ContractAction
              {
                  Id = 6,
                  Name = "تم الاسترجاع",
              }, new ContractAction
              {
                  Id = 7,
                  Name = "تم الاغلاق ",
              }
          );
            modelbuilder.Entity<ReceiptDocType>()
              .HasData(new ReceiptDocType
              {
                  Id = 1,
                  Name = "سند صرف "
              },
              new ReceiptDocType
              {
                  Id = 2,
                  Name = "سند قبض",
              }
          );

        }

        // Lookups        
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }


        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        //public DbSet<User> Users { get; set; }




        public DbSet<BankDetail> BankDetails { get; set; }

        public DbSet<JobType> JobTypes { get; set; }

        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserDelegate> UserDelegates { get; set; }

        public DbSet<DelegateType> DelegateTypes { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        public DbSet<Arrival> Arrivals { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ForeignAgency> ForeignAgencies { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Partner> Partners { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        
        public DbSet<Religion> Religions { get; set; }
        public DbSet<SocialStatus> SocialStatuses { get; set; }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<ContractStatus> ContractStatuses { get; set; }
        public DbSet<ContractAction> ContractAction { get; set; }

        public DbSet<ContractHistory> ContractHistories { get; set; }
        public DbSet<ContractSelect> ContractSelects { get; set; }
        public DbSet<ContractDelegation> ContractDelegations { get; set; }
        public DbSet<ContractVisa> ContractVisas { get; set; }
        public DbSet<ContractTicket> ContractTickets { get; set; }
        public DbSet<ReceiptDoc> ReceiptDocs { get; set; }
        public DbSet<ReceiptDocType> ReceiptDocTypes { get; set; }

        public DbSet<SpecialEmployee> SpecialEmployees { get; set; }
        public DbSet<SpecificContract> SpecificContracts { get; set; }

    }
}
